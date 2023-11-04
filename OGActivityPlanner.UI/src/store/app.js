// Utilities
import { defineStore } from 'pinia';
import { COOKIES } from '@/utils/constants';

export const useAppStore = defineStore('app', {
  state: () => ({
    displayMode: COOKIES.VALUE_UNSET,
  }),
  getters: {
    isDarkMode() {
      return this.displayMode === COOKIES.VALUE_DARKMODE;
    },
    isLightMode() {
      return this.displayMode === COOKIES.VALUE_LIGHTMODE;
    },
  },
  actions: {
    setDisplayMode(mode) {
      this.displayMode = mode;
    },
  },
});
