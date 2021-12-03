import Vue from "vue";
import Router from "vue-router";
import Home from "./views/Home/Home.vue";

Vue.use(Router);

const router = new Router({
    // mode: "history",
    base: process.env.BASE_URL,
    linkExactActiveClass: "is-active",
    routes: [{
        path: "/",
        name: "Home",
        component: Home,
    }
    ],
});

router.beforeEach((to, from, next) => {
    const publicPages = [
        "home",
    ];
    
    next();
});

export default router;