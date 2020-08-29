import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Permisos from '../views/Permisos.vue'
import Tipo_permisos from '../views/Tipo_permisos.vue'

Vue.use(VueRouter)

  const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/permisos',
    name: 'Permisos',
    component: Permisos
  },
  {
    path: '/tipos_permisos',
    name: 'Tipo_permisos',
    component: Tipo_permisos
  },
  {
    path: '/about',
    name: 'About',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
