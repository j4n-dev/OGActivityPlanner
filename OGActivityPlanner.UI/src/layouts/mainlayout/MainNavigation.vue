<template>
    <v-bottom-navigation color="green darken-1" grow>
      <v-btn v-for="item in items" :key="item.title" :to="item.to">
          <v-icon>{{ item.icon }}</v-icon>
          {{ item.title }}
      </v-btn>
    </v-bottom-navigation>
  </template>
  
  <script>
  export default {
    data() {
      return {
        items: [
          { title: this.$t("labels.activities"), to: '/activities', icon: 'mdi-view-dashboard' },
          { title: this.$t("labels.votes"), to: '/votes', icon: 'mdi-vote' },
          { title: this.$t("labels.suggestions"), to: '/suggestions', icon: 'mdi-account-group' },
          { title: this.$t("labels.options"), to: '/options', icon: 'mdi-cogs' },
        ],
      };
    },
  };
  </script>
  
  <style scoped>
 
 .active {
    background-color: rgba(255, 255, 255, 0.2) !important;
  }
  
  </style>
  