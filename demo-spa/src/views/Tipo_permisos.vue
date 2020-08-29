<template>
        <div>
        <!-- <v-card
            height="500px"
            width="800px"
            class="mx-auto"
            centered
        >
            <v-card-title primary-title>
                <h3>Tipos de Permisos</h3> 
            </v-card-title>
            <v-layout align-end justify-end>
                <v-card-actions align-end justify-end>
                    <v-btn color="primary" @click="dialog = true">Add new</v-btn>
                </v-card-actions>
            </v-layout>

        </v-card> -->
        <v-data-table
            :headers="headers"
            :items="tipo_permiso"
            :search="search"
            sort-by="nombre"
            class="elevation-1"
            :loading="tipo_permiso.length <= 0" loading-text="Cargando... favor espere"
        >
            <template v-slot:item.estado="{ item }">                
                <v-btn text :color="getColor(item.estado)" dark>{{ item.estado == true ? "Activo" : "Inactivo" }}</v-btn>
            </template>
            
            <template v-slot:item.actions="{ item }">      
                <v-icon
                    small
                    class="mr-2"
                    @click="editItem(item)"
                >
                    create
                </v-icon>
                
                
                <!-- ------------Activar Registro-----------(NO EN USO)---->
                <v-icon
                    small 
                    @click="changeStatus(1, item)"     
                    v-if="item.estado == false"
                >      
                    check
                </v-icon>
                <!--  -->

                <!-- -------------Desactivar Registro-------------(NO EN USO) --> 
                <v-icon
                    small
                    @click="changeStatus(2, item)"
                    v-if="item.estado == true"
                >
                    not_interested
                </v-icon>
            
            </template>
            <template v-slot:top>
            <v-toolbar flat color="white">
                <v-toolbar-title>Tipos de Permiso</v-toolbar-title>
                <v-divider
                class="mx-4"
                inset
                vertical
                ></v-divider>
                <v-spacer></v-spacer>
                <v-text-field 
                name="name"
                label="Búsqueda"
                append-icon="search"          
                class="text-xs-center"
                v-model="search"
                single-line
                hide-details
                ></v-text-field>
                <v-spacer></v-spacer>  

                <!-- dialog principal inicio -->

                <v-dialog v-model="dialog" max-width="500px">
                <template v-slot:activator="{ on }">
                    <v-btn color="primary" dark class="mb-2" v-on="on">Nuevo</v-btn>
                </template>
                <v-card>
                    <v-card-title>
                    <span class="headline">{{ formTitle }}</span>
                    </v-card-title>

                    <v-card-text>
                    <v-container>
                        <v-form ref="form" v-model="valid">
                        <v-row>
                            <v-col cols="6" sm="6" md="6">
                            <v-text-field 
                                :class="{ 'hasError': $v.editedItem.nombre.$error }" 
                                v-model="editedItem.nombre"
                                :rules="codeRules" 
                                label="Nombre"
                                required
                            ></v-text-field>
                            </v-col> 

                            <v-col cols="6" sm="6" md="6">
                            <v-text-field 
                                v-model="editedItem.telefono" 
                                label="Numero de telefono"
                            ></v-text-field>
                            </v-col>                                      
                        </v-row>
                        
                        <v-row>  
                            <v-col cols="6" sm="6" md="6">                      
                            <v-select
                                :class="{ 'hasError': $v.editedItem.tipo_documento.$error }"
                                :items="tipoDoc"                        
                                v-model="editedItem.tipo_documento"
                                :rules="categoriaRules"
                                label="Tipo de documento"
                                required
                            ></v-select>                      
                            </v-col>             

                            <v-col cols="6" sm="6" md="6">
                            <v-text-field 
                                v-model="editedItem.num_documento" 
                                :counter="11"
                                :rules="nombreRules"
                                label="Numero de documento"
                                required
                            ></v-text-field>                    
                            </v-col>                   
                        </v-row>
                        
                        
                        <v-row>
                            <v-col cols="6" sm="6" md="6">
                            <v-text-field 
                                v-model="editedItem.direccion"                         
                                label="Direccion"
                            ></v-text-field>
                            </v-col> 

                            <v-col cols="6" sm="6" md="6">
                            <v-text-field 
                                v-model="editedItem.email" 
                                label="Email"
                            ></v-text-field>
                            </v-col>                    
                        </v-row>

                        
                                            
                        

                        </v-form>
                    </v-container>
                    </v-card-text>

                    <v-card-actions>
                    <v-spacer></v-spacer>

                    <v-btn color="blue darken-1" 
                        text v-on:click="resetValidation" 
                        @click="close">
                        Cancelar
                    </v-btn>

                    <v-btn color="blue darken-1"
                        text @click="save"
                        :disabled="!valid"
                        >
                        Guardar
                    </v-btn>

                    </v-card-actions>
                </v-card>
                </v-dialog>

                <!-- dialog principal fin -->     

                

                
            </v-toolbar>
            </template>
            
            <template v-slot:no-data>
                <v-btn color="primary" @click="loadPermitions">Reset</v-btn>
            </template>
        </v-data-table>
        
    </div>
</template>

<script>
import axios from 'axios';
export default {
    data: () => ({
        //
        
        valid: false,
        editedItem: {},
        search: '',
        dialog: false,
        tipo_permiso: [],
        headers: [
            { text: 'Opciones', value: 'actions', sortable: false},
            { text: 'Tipo de Permiso', value: 'nombre'},
            { text: 'Descripcion', value: 'descripcion'},
            { text: 'Condicion', value: 'estado'}
        ]
    }),
    computed: {
      formTitle () {
        return this.editedIndex === -1 ? 'Agregar Cliente' : 'Editar Cliente'
      },
    },
    mounted() {
        this.loadPermitions();
    },
    methods: {
        loadPermitions(){
            axios.get("https://localhost:44369/api/TipoPermisos/GetTipoPermisos").then( response => {
                this.tipo_permiso = response.data;
                console.log(response.data);
            });
        },
        editItem(item){
            console.log(item)
        },
        changeStatus(accion, item){
            this.dialog1 = true;
            this.adNombre = item.nombre;
            this.adId = item.idusuario;
            if(accion === 1) {          //activar registro
            this.adAccion = 1;
            }else if (accion === 2){      //desactivar registro          
            this.adAccion = 2;
            }
        },
        getColor (received) {
            if (received == true) return 'green'
            else if (received == "Inactivo") return 'red'
            else return 'white'
        }, 
        
    },
     
}
</script>