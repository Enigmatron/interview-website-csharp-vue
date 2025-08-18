<template>
  <div class="pb-4">
    <button type="button" class="btn btn-primary float-start mb-3" data-bs-toggle="modal"
      data-bs-target="#clientCreationModal"> New Client </button>

    <CreateClientForm />

    <table class="table table-striped table-hover table-bordered">
      <thead>
        <tr>
          <th>ID</th>
          <th>Name</th>
          <th>Company</th>
          <th>Email</th>
          <th>Address</th>
        </tr>
      </thead>
      <tbody>
        <template v-if="$store.state.tableIsLoading">
          <tr class="placeholder-glow">
            <td colspan="100%"><span class="loading-spinner">Loading<span class="dot one">.</span><span
                  class="dot two">.</span><span class="dot three">.</span></span></td>
          </tr>
        </template>
        <template
          v-if="$store.state.clientList.length || $store.state.topClient && Object.keys($store.state.topClient).length">
          <template v-if="$store.state.topClient && Object.keys($store.state.topClient).length">
            <tr class="table-primary" :key="$store.state.topClient.id" @click="goToClient($store.state.topClient.id)">
              <td>{{ $store.state.topClient.id }}</td>
              <td> {{ $store.state.topClient.name }}</td>
              <td> {{ $store.state.topClient.company }}</td>
              <td> {{ $store.state.topClient.email }}</td>
              <td> {{ $store.state.topClient.address }}</td>
            </tr>
          </template>
          <tr v-for="client in $store.state.clientList" :key="client.id" @click="goToClient(client.id)">
            <td>{{ client.id }}</td>
            <td> {{ client.name }}</td>
            <td> {{ client.company }}</td>
            <td> {{ client.email }}</td>
            <td> {{ client.address }}</td>
          </tr>
        </template>
        <template v-else-if="!$store.state.tableIsLoading">
          <tr>
            <td colspan=" 100%">No data available.</td>
          </tr>
        </template>
      </tbody>
    </table>
  </div>
</template>

<script>
import CreateClientForm from "@/components/CreateClientForm.vue";

export default {
  name: 'ClientTable',
  components: {
    CreateClientForm,
  },
  methods: {
    goToClient(id) {
      this.$router.push({ name: 'ClientManagement', params: { id } })
    },
  }
}
</script>

<style lang="scss">
.loading-spinner {
  .dot {
    animation: blink 2.5s infinite;
    opacity: 0;
  }

  .dot.one {
    animation-delay: 0s;
  }

  .dot.two {
    animation-delay: 0.75s;
  }

  .dot.three {
    animation-delay: 1.25s;
  }

}

@keyframes blink {
  0% {
    opacity: 0;
  }

  20% {
    opacity: 1;
  }

  100% {
    opacity: 0;
  }
}


.table-hover tbody tr:hover {
  background-color: aqua !important;
}
</style>