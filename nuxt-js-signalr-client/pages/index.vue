<template>
  <div class="">
    <div class="container">
      <div class="row">&nbsp;</div>
      <div class="row">
        <v-text-field label="User" v-model="user"></v-text-field>
      </div>
      <div class="row">
        <v-text-field label="Message" v-model="message"></v-text-field>
      </div>
      <div class="row">&nbsp;</div>
      <div class="row">
        <div class="col-6">
            <v-btn @click="sendMessage" id="sendButton">Send Message</v-btn>
        </div>
      </div>
    </div>
    <div class="row">
      {{messagesList}}
    <div class="col-6">
      <ul v-for="item in messagesList" :key="item">
        <li>{{item}}</li>
      </ul>
    </div>
    </div>
    <!-- <script src="~/js/signalr/dist/browser/signalr.js"></script>
    <script src="~/js/chat.js"></script> -->
  </div> 
</template>

<script>
const signalR = require('@microsoft/signalr');

export default {
  data: ()=> ({
    user : '',
    message : '',
    connection: [],
    messagesList : []
  }),
  mounted(){
    debugger
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl("https://localhost:44373/chatHub")
      .withAutomaticReconnect()
      .build();
    
    debugger
    this.connection.on("ReceiveMessage", function (user, message) {
      debugger
      var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
      debugger
      var encodedMsg = user + " says " + msg;
      debugger
      this.messagesList.push(encodedMsg)
      debugger
    });

    debugger
    this.connection.start().then(() => {
      console.log('Connected to signalr chat hub')
    }).catch(function (err) {
      return console.error(err.toString());
    });
    debugger
  },
  methods:{
    sendMessage(){
      this.connection.invoke("SendMessage", this.user, this.message)
      .catch(function (err) {
        return console.error(err.toString());
      });
    }
  }
}
</script>
