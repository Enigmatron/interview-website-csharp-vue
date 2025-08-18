<template>
  <div>
    <nav class="nav border-bottom bg-body pb-3">
      <router-link to="/" class="nav-link" :class="{ disabled: $route.path === '/' || $route.path === '/dashboard' }"
        @click.native.prevent="$route.path === '/' || $route.path === '/dashboard'">Home</router-link>
      <router-link to="/about" class="nav-link">About</router-link>
      <router-link to="/about" class="nav-link">Contact</router-link>
    </nav>
    <div id="app" class="min-vh-100 bg-body mx-4">

      <router-view class="pt-5 " />


    </div>
    <footer class="bg-dark text-light py-4 mt-auto">
      <div class="container d-flex flex-column flex-md-row justify-content-between align-items-center">
        <div class="mb-3 mb-md-0">
          <span>&copy; {{ new Date().getFullYear() }} Idries Kysia. All rights reserved.</span>
        </div>
        <ul class="nav">
          <li class="nav-item">
            <router-link to="/" class="nav-link text-light px-2">Home</router-link>
          </li>
          <li class="nav-item">
            <router-link to="/about" class="nav-link text-light px-2">About</router-link>
          </li>
          <li class="nav-item">
            <router-link to="/contact" class="nav-link text-light px-2">Contact</router-link>
          </li>
        </ul>
      </div>
    </footer>
  </div>
</template>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>
