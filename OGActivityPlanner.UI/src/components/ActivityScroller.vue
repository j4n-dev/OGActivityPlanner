<template>
    <v-container fluid>
      <v-row justify="center">
        <v-col cols="10" sm="8" md="6">
          <v-window v-model="active" direction="vertical">
            <v-window-item
              v-for="item in items"
              :key="item.id"
            >
              <v-card
                :color="item.color"
                dark
                height="500px"
                class="d-flex flex-column justify-center align-center"
              >
                <v-card-title>{{ item.title }}</v-card-title>
                <v-card-text>{{ item.description }}</v-card-text>
              </v-card>
            </v-window-item>
          </v-window>
        </v-col>
      </v-row>
    </v-container>
  </template>
  
  <script>
  export default {
    data() {
      return {
        active: 0,
        items: [
          { id: 1, title: 'Card 1', description: 'This is card 1', color: 'red' },
          { id: 2, title: 'Card 2', description: 'This is card 2', color: 'blue' },
          { id: 3, title: 'Card 3', description: 'This is card 3', color: 'green' },
          // ... add more items as needed
        ],
      };
    },
  
    watch: {
      active(val) {
        if (val === this.items.length - 1) {
          // Load more items when the last card is reached
          // You can make an API call here to fetch more items
          // For simplicity, I'm just appending more items to the existing list
          const lastId = this.items[this.items.length - 1].id;
          for (let i = 1; i <= 3; i++) {
            this.items.push({
              id: lastId + i,
              title: `Card ${lastId + i}`,
              description: `This is card ${lastId + i}`,
              color: this.getRandomColor()
            });
          }
        }
      }
    },
  
    methods: {
      getRandomColor() {
        const colors = ['red', 'blue', 'green', 'yellow', 'purple', 'pink'];
        return colors[Math.floor(Math.random() * colors.length)];
      },
    },
  };
  </script>
  
  <style scoped>
  /* Add any additional styles here */
  </style>
  