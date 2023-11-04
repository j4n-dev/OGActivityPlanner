<template>
  <v-app>
    <MainHeader :displayMode="displayMode" @displayModeToggle="toggleDisplayMode()" />

    <v-main>
      <router-view v-slot="{ Component }">
        <transition name="fade" mode="out-in">
          <component :is="Component" />
        </transition>
      </router-view>
    </v-main>

    <MainNavigation />
  </v-app>
</template>

<script>
// Components
import MainHeader from './MainHeader.vue';
import MainNavigation from './MainNavigation.vue';
// Stores
import { useAppStore } from '@/store/app';
// Utilities
import { COOKIES } from '@/utils/constants';
import { CookieHelper, StringHelper } from '@/utils/helpers';
import { useTheme } from 'vuetify';

export default {
  name: 'MainLayout',

  data() {
    return {
      themeModule: undefined,
      displayMode: undefined,
    };
  },

  components: { MainHeader, MainNavigation },

  mounted() {
    let preferedDisplayMode = undefined;

    if ((this.cookieDisplayMode !== COOKIES.VALUE_DARKMODE && this.cookieDisplayMode !== COOKIES.VALUE_LIGHTMODE) || StringHelper.isNullOrWhitespace(this.cookieDisplayMode, true)) {
      let userPrefersDark = window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches;
      preferedDisplayMode = userPrefersDark ? COOKIES.VALUE_DARKMODE : COOKIES.VALUE_LIGHTMODE;
    }

    this.displayMode = preferedDisplayMode === undefined ? this.cookieDisplayMode : preferedDisplayMode;
    this.themeModule = useTheme();
  },

  methods: {
    toggleDisplayMode() {
      this.displayMode = this.displayMode === COOKIES.VALUE_DARKMODE ? COOKIES.VALUE_LIGHTMODE : COOKIES.VALUE_DARKMODE;
    },
  },

  computed: {
    appStore() {
      return useAppStore();
    },

    cookieDisplayMode() {
      return CookieHelper.get(COOKIES.KEY_DISPLAYMODE);
    },
  },

  watch: {
    displayMode(newDisplayMode) {
      if (!newDisplayMode) throw 'falsy newDisplayMode, please reload';
    
      CookieHelper.setForever(COOKIES.KEY_DISPLAYMODE, newDisplayMode);
      this.appStore.setDisplayMode(newDisplayMode);

      this.themeModule.global.name = newDisplayMode.toLowerCase();
    },
  },
};
</script>

<style scoped>
.fade-enter-active, .fade-leave-active {
  transition: opacity 0.2s;
}
.fade-enter-from, .fade-leave-to {
  opacity: 0;
}
.fade-enter-to, .fade-leave-from {
  opacity: 1;
}

</style>
