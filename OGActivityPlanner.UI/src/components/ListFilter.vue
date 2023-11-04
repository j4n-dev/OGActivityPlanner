<template>
  <v-btn-toggle v-model="mode" color="green darken-1" group>
    <v-btn value="search">
      <v-row no-gutters justify="center" class="flex-column">
        <v-col>
          <v-icon class="hidden-sm-and-down"> mdi-tab-search </v-icon>
          <v-icon class="hidden-sm-and-up" style="font-size: 24px;"> mdi-tab-search </v-icon>
        </v-col>
        <v-col class="hidden-sm-and-down"> {{ $t('common.search') }} </v-col>
      </v-row>
    </v-btn>

    <v-btn value="filter">
        <v-row no-gutters justify="center" class="flex-column">
        <v-col>
          <v-icon class="hidden-sm-and-down"> mdi-filter-variant </v-icon>
          <v-icon class="hidden-sm-and-up" style="font-size: 24px;"> mdi-filter-variant </v-icon>
        </v-col>
        <v-col class="hidden-sm-and-down"> {{ $t('common.filter') }} </v-col>
      </v-row>
    </v-btn>

    <v-btn value="sort">
        <v-row no-gutters justify="center" class="flex-column">
        <v-col>
          <v-icon class="hidden-sm-and-down"> mdi-sort </v-icon>
          <v-icon class="hidden-sm-and-up" style="font-size: 24px;"> mdi-sort </v-icon>
        </v-col>
        <v-col class="hidden-sm-and-down"> {{ $t('common.sort') }} </v-col>
      </v-row>
    </v-btn>
  </v-btn-toggle>
</template>

<script>
export default {
  data() {
    return {
      mode: 'search',
    };
  },

  methods: {},
};
</script>
