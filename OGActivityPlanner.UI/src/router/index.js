// Composables
import { createRouter, createWebHistory } from 'vue-router';

const routes = [
  {
    path: '/',
    component: () => import('@/layouts/mainlayout/MainLayout.vue'),
    children: [
      {
        path: '/',
        redirect: '/Activities',
      },
      {
        path: 'Activities',
        name: 'Activities',
        component: () => import('@/views/Activities.vue'),
      },
      {
        path: 'Votes',
        name: 'Votes',
        component: () => import('@/views/Votes.vue'),
      },
      {
        path: 'Suggestions',
        name: 'Suggestions',
        component: () => import('@/views/Suggestions.vue'),
      },
      {
        path: 'Options',
        name: 'Options',
        component: () => import('@/views/Options.vue'),
      },
    ],
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
