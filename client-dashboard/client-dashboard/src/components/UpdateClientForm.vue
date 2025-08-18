<template>
  <form @submit.prevent="handleSubmit" class="container mx-auto py-10 px-4">
    <input v-if="client" type="hidden" v-model="client.id" />
    <input v-if="client" type="hidden" v-model="client.active" />
    <h1 class="row mb-8 float-left ps-3">Update Client</h1>


    <fieldset class="form-group card">
      <div class="input-group card-body border-bottom px-5">

        <div class="form-floating">
          <input v-model="client.name" type="text" class="form-control" id="floatingInputName" placeholder="Name"
            required>
          <label for="floatingInputName">Name</label>
        </div>

        <div class="form-floating">
          <input v-model="client.email" type="email" class="form-control" id="floatingInputEmail" placeholder="Email">
          <label for="floatingInputEmail">Email</label>
        </div>
      </div>
      <div class="input-group card-body border-bottom px-5">

        <div class="form-floating">
          <input v-model="client.company" type="text" class="form-control" id="floatingInputCompany"
            placeholder="Company">
          <label for="floatingInputCompany">Company</label>
        </div>

        <div class="form-floating">
          <input v-model="client.address" type="text" class="form-control" id="floatingInputAddress"
            placeholder="Address">
          <label for="floatingInputAddress">Address</label>
        </div>
      </div>

      <div class="input-group p-4 border-bottom">
        <label for="phone-input" class="form-label">Phone Number</label>
        <div class="input-group">
          <input v-model="newPhoneNumber" type="tel" v-mask="'(###) ###-####'" class="form-control" id="phone-input"
            placeholder="Phone Number">
          <button type="button" class="btn btn-info" @click="addPhoneNumber(newPhoneNumber)">Add Number</button>
        </div>
      </div>

      <div class="input-group px-4 pt-4">
        <div class="input-group mb-4" v-for="(phone, index) in phoneList" :key="index">
          <input disabled type="text" class="form-control bg-transparent" :value="phone.formattedNumber" />
          <button type="button" class="btn btn-danger" @click="removePhoneNumber(index)">Delete</button>
        </div>
      </div>

    </fieldset>

    <div class="d-flex justify-content-between w-100 px-4 pt-2">
      <button type="button" class="btn btn-danger" @click="archiveClient">Archive</button>
      <button type="submit" class="btn btn-primary">Save</button>
    </div>
  </form>
</template>

<script>
export default {
  name: 'UpdateClientForm',
  props: {
    clientId: {
      type: Number,
      required: true
    }
  },
  methods: {
    handleSubmit() {
      console.log("submit")
      if (!this.client) return;
      this.client.phoneNumbers = this.phoneList
      this.client.active = true
      this.$store.dispatch('putUpdateClient', this.client)
        .then(() => {
          console.log('Client updated successfully');
          this.$router.push('/dashboard');
        })
        .catch(err => {
          console.error('Failed to update client:', err);
        });
    },
    removePhoneNumber(index) {
      if (!this.client || !Array.isArray(this.phoneList)) return;
      this.phoneList.splice(index, 1);
    },
    archiveClient() {
      if (!this.client || !this.client.id) return;
      this.$store.dispatch('postArchiveClientById', this.client.id)
        .then(() => {
          console.log('Client archived');
          this.$store.dispatch("fetchClientsDashboard")
          this.$router.push('/dashboard');
        })
        .catch(err => {
          console.error('Failed to archive client:', err);
        });
    },
    addPhoneNumber(newNumber) {
      if (!newNumber || !this.client) return;
      if (!this.phoneList) {
        this.phoneList = [];
      }
      this.phoneList.push({
        formattedNumber: newNumber,
      });
      this.newPhoneNumber = ''
    }
  },
  data() {
    return {
      phoneList: [],
      client: null,
      newPhoneNumber: ''
    }
  },
  mounted() {
    const res = this.$store.dispatch('fetchClientById', this.$route.params.id).then(res => {
      this.client = res.data
      this.phoneList = this.client.phoneNumbers || []
    });
  }
}
</script>