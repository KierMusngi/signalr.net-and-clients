<template>
  <v-layout
    column
    justify-center
    align-center
  >
    <v-flex
      xs12
      sm8
      md6
    >
      <div class="text-center">
        <logo />
        <vuetify-logo />
      </div>
      <v-card>
        <v-card-title class="headline">
          Welcome to the Vuetify + Nuxt.js template
        </v-card-title>
        {{conn}}
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
import Logo from '~/components/Logo.vue'
import VuetifyLogo from '~/components/VuetifyLogo.vue'
const signalR = require('@microsoft/signalr')

export default {
  data(){
    return{
      conn: ''
    }
  },
  components: {
    Logo,
    VuetifyLogo
  },
  mounted(){
    this.funcfunc()
  },
  methods:{
    funcfunc(){
      debugger
      const connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:44314/chat")
        .build()

      this.conn = connection.state
      console.log(connection)
      debugger
      connection.start()
        .then(() => {
          debugger
          connection.invoke("Send", "Hello")
      }).catch((err) => {
        console.log(err)
      });
      debugger
    }
  }
}
</script>
