import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'Captcha',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44342',
    redirectUri: baseUrl,
    clientId: 'Captcha_App',
    responseType: 'code',
    scope: 'offline_access Captcha',
  },
  apis: {
    default: {
      url: 'https://localhost:44342',
      rootNamespace: 'Abp.Captcha',
    },
    Captcha: {
      url: 'https://localhost:44379',
      rootNamespace: 'Abp.Captcha',
    },
  },
} as Environment;
