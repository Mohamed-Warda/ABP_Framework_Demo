import { RoutesService, eLayoutType } from '@abp/ng.core';
import { inject, provideAppInitializer } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routes = inject(RoutesService);
  routes.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/books',
        name: '::Menu:Books',
        iconClass: 'fas fa-book',
        order:2,
        layout: eLayoutType.application,
      //  requiredPolicy: 'ABPDemo.Books',
      },

    {
      path: 'categories',
      name: 'Categories',
      iconClass: 'fas fa-list',
      order: 3,
      layout: eLayoutType.application,
    },
    {
      path: 'products',
      name: 'Products',
      iconClass: 'fas fa-box',
      order: 4,
      layout: eLayoutType.application,
    },
  ]);
}
