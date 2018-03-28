import { PLATFORM } from 'aurelia-pal';
import style from '../styles/style.scss';

export class index {
    constructor() {

    }

    configureRouter(config, router) {
        this.router = router;
        config.map([
            { route: ['', 'welcome'],       name: 'welcome',    moduleId: PLATFORM.moduleName('welcome') },
            { route: 'Accounts/Login',      name: 'Login',      moduleId: PLATFORM.moduleName('Accounts/Login') }
        ])
    }
}