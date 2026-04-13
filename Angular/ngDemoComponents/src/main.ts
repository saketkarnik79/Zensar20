import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { App } from './app/app';
import { Child1 } from './app/child1/child1';

// bootstrapApplication(App, appConfig)
// //bootstrapApplication(Child1, appConfig)
//   .catch((err) => console.error(err));

// bootstrapApplication(App, appConfig)
//   .catch((err) => console.error(err));

bootstrapApplication(App, appConfig)
  .then(appRef => {
    //Bootstrap the Child1 component as well
    appRef.bootstrap(Child1);
    //appRef.bootstrap(Child2);
  })
  .catch((err) => console.error(err));