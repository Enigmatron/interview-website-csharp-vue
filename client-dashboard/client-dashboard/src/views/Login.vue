<!-- This page is just for kayfabe fun to give you a more cohesive feeling for the application. it's not for full functioning authentication and will reset your "credentials" -->

<template>
    <div class="login container d-flex justify-content-center align-items-center">
        <div class="card" style="width: 30rem;">
            <div class="card-body">
                <p class="align-start">Login</p>
                <div class="form-floating m-3">
                    <input type="email" class="form-control" id="floatingInput" placeholder="Email">
                    <label for="floatingInput">Email</label>
                </div>
                <div class="form-floating m-3">
                    <input type="password" class="form-control" id="floatingInput" placeholder="Password">
                    <label for="floatingInput">Password</label>
                </div>
                <div>
                    <span class="d-inline-block float-start m-3" tabindex="0" data-bs-toggle="tooltip"
                        data-bs-placement="bottom" data-bs-custom-class="signup-tooltip"
                        data-bs-title="under construction, try the login button">
                        <button type="button" disabled class="btn btn-secondary">Sign Up</button>
                    </span>
                    <button type="button" class="btn btn-primary float-end m-3" @click="login()"
                        data-bs-toggle="tooltip" data-bs-placement="bottom" data-bs-custom-class="login-tooltip"
                        data-bs-title="admin access approved, please click">Login</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
//instancing and populating ClientDashboard view with API data
import { Tooltip } from 'bootstrap';

export default {
    name: "Login",

    methods: {
        login() {
            this.$store.commit('markLoginAttempt');
            sessionStorage.setItem('hasAttemptedLogin', 'true');
            this.$router.replace('/dashboard');
        }
    },
    mounted() {
        const signupTooltip = this.$el.querySelector('[data-bs-toggle="tooltip"][data-bs-custom-class="signup-tooltip"]');
        if (signupTooltip) {
            new Tooltip(signupTooltip);
        }
        const loginTooltip = this.$el.querySelector('[data-bs-toggle="tooltip"][data-bs-custom-class="login-tooltip"]');
        if (loginTooltip) {
            new Tooltip(loginTooltip, {
                delay: { show: 1200, hide: 0 } // delay in ms: show after 2 seconds
            });
        }
    }
};
</script>
