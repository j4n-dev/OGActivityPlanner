/**
 * plugins/index.js
 *
 * Automatically included in `./src/main.js`
 */

// Plugins
import vuetify from './vuetify';
import pinia from '../store';
import router from '../router';
import i18n from './i18n';

export function registerPlugins(app) {
  app.use(i18n).use(vuetify).use(router).use(pinia);
}
