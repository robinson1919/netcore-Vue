<template>
  <v-app id="inspire">
    <v-navigation-drawer
      v-model="drawer"
      :clipped="$vuetify.breakpoint.lgAndUp"
      app
    >
      <v-list shaped >        
        <template v-for="item in items" :to="item.url">
          <v-row v-if="item.heading" :key="item.heading" align="center" >
            <v-col cols="6">
              <v-subheader v-if="item.heading" >
                {{ item.heading }}
              </v-subheader>
            </v-col>
            <v-col cols="6" class="text-center">
              <a href="#!" class="body-2 black--text">EDIT</a>
            </v-col>
          </v-row>
          <v-list-group
            v-else-if="item.children"
            :key="item.text"
            v-model="item.model"
            :prepend-icon="item.model ? item.icon : item['icon-alt']"
            append-icon=""
          >
            <template v-slot:activator >
              <v-list-item-content >
                <v-list-item-title>
                  {{ item.text }}
                </v-list-item-title>
              </v-list-item-content>
            </template>
            <v-list-item
              v-for="(child, i) in item.children"
              :key="i"
              link
              :to="child.url"
            >
              <v-list-item-action v-if="child.icon" >
                <v-icon>{{ child.icon }}</v-icon>
              </v-list-item-action>
              <v-list-item-content> 
                <v-list-item-title>
                  {{ child.text }}
                </v-list-item-title>
              </v-list-item-content>
            </v-list-item>
          </v-list-group>
          <v-list-item v-else :key="item.text" link :to="item.url" >
            <v-list-item-icon >
              <v-icon>{{ item.icon }}</v-icon>
            </v-list-item-icon>
            <v-list-item-content >
              <v-list-item-title>
                {{ item.text }}
              </v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </template>
      </v-list>    
    </v-navigation-drawer>

    <v-app-bar
      :clipped-left="$vuetify.breakpoint.lgAndUp"
      app
      color="blue darken-3"
      dark
      fixed
    >
      <v-app-bar-nav-icon @click.stop="drawer = !drawer"/>
      <v-toolbar-title style="width: 300px" class="ml-0 pl-4">
        
      </v-toolbar-title>      
      <v-spacer />
        
    </v-app-bar>
    <v-main>
      <v-container fluid>
        <v-slide-y-transition mode="out-in">
          <router-view></router-view>
        </v-slide-y-transition>
      </v-container>
    </v-main>
    <v-footer dark height="auto">
      <v-layout justify-center>
        <v-flex text-xs-center>
          <v-card flat tile color="secondary" class="white--text">
            <v-card-text class="white--text pt-0 pb-0 text-center">
              <!-- ContaxCloud &copy;2020 -->
            </v-card-text>
          </v-card>
        </v-flex>
      </v-layout>
    </v-footer>
    
  </v-app>
</template>

<script>
// import HelloWorld from './components/HelloWorld';

export default {
  name: 'App',

  components: {
    // HelloWorld,
  },

  data: () => ({
    drawer: null, 
    log: false,  
    items1: [],   
    items: [
      { text: 'Home', icon: 'home', 'icon-alt': 'home', url: '/',
        model: true       
      },
      { text: 'Permisos', icon: 'table_chart', 'icon-alt': 'permisos', url: '/permisos',
        model: true       
      },
      { text: 'Tipos de Permisos', icon: 'table_chart', 'icon-alt': 'Tipo_permisos', url: '/tipos_permisos',
        model: true       
      },
      // 
    ],
  }),
};
</script>
