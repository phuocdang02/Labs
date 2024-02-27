import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { LoginRegisterComponent } from './app/app.component';

bootstrapApplication(LoginRegisterComponent, appConfig).catch((err) =>
  console.error(err)
);
