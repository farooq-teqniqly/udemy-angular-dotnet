# Angular Client

## Setup

### Install Angular CLI

`npm install -g @angular/cli@12`

### Check Angular Version

`ng --version`

### Create Angular Project

`ng new client --strict false`

### Configure for SSL

1. Create a folder named `cert` inside the application.
2. Import certificate and key file to the `cert` folder.
3. Add the following to the `server` section in `angular.json`:

```json
"options": {
            "sslKey": "cert/server.key",
            "sslCert": "cert/server.crt",
            "ssl": true
          },
```

4. Restart the Angular application.

### Install ngx-bootstrap

```
npm install ngx-bootstrap@6.2.0 --save
npm install bootstrap@4.6.0 --save
npm install font-awesome --save
```

Import `BrowsersAnimationModule` in `app.component.ts`:<br>
`import { BrowserAnimationsModule } from '@angular/platform-browser/animations';`
