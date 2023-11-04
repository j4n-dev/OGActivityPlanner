<template>
  <v-app-bar rounded>
    <template v-slot:title>
      <v-row style="position: absolute; width: 100%; display: flex; justify-content: center; top: 20px;">
          <ListFilter />
      </v-row>
    </template>
    <template v-slot:append>
      <v-avatar color="surface-variant" size="48">420</v-avatar>
    </template>
  </v-app-bar>
</template>

<script>
import ListFilter from '@/components/ListFilter.vue';
import { COOKIES } from '@/utils/constants';

export default {
  name: 'MainHeader',

  props: { displayMode: String },

  emits: ['displayModeToggle'],

  components: { ListFilter },

  methods: {
    toggleDisplayMode() {
      this.$emit('displayModeToggle');
    },
  },
  computed: {
    displayModeIcon() {
      return this.displayMode === COOKIES.VALUE_DARKMODE ? 'mdi-weather-sunny' : 'mdi-weather-night';
    },
  },
};
</script>
