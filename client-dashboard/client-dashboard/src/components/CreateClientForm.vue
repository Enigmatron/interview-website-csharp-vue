<template>
    <div class="modal fade" id="clientCreationModal" tabindex="-1" aria-labelledby="clientCreationModalLabel"
        aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="clientCreationModalLabel">Create New Client</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <form @submit.prevent="submitForm">
                    <div class="modal-body">
                        <div class="form-floating">
                            <input v-model="name" type="text" class="form-control mb-3" id="floatingInput"
                                placeholder="Name" required>
                            <label for="floatingInput">Name</label>
                        </div>
                        <div class="form-floating">
                            <input v-model="company" type="text" class="form-control mb-3" id="floatingInput"
                                placeholder="Company">
                            <label for="floatingInput">Company</label>
                        </div>
                        <div class="form-floating">
                            <input v-model="email" type="email" class="form-control mb-3" id="floatingInput"
                                placeholder="Email">
                            <label for="floatingInput">Email</label>
                        </div>
                        <div class="form-floating">
                            <input v-model="address" type="text" class="form-control mb-3" id="floatingInput"
                                placeholder="Address">
                            <label for="floatingInput">Address</label>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button float-left" class="btn btn-secondary"
                            data-bs-dismiss="modal">Close</button>
                        <button type="submit" class="btn btn-primary">Save changes</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</template>

<script>
export default {

    name: 'CreateClientForm',

    data() {
        return {
            name: '',
            email: '',
            company: '',
            address: '',
            emailValid: false
        };
    },
    methods: {
        ///
        /// the modal system has to be swapped out for a package to handle modals rather than bootstrap to programatically close the modal reliably
        ///

        // closeModal() {
        //     const modalEl = document.getElementById('clientCreationModal');
        //     const modalInstance = Modal.getInstance(modalEl) || new Modal(modalEl);
        //     modalInstance.hide();
        //     // modalEl.classList.remove('show');
        //     // modalEl.style.display = 'none';
        //     // modalEl.removeAttribute('aria-modal');
        //     // modalEl.removeAttribute('role');
        //     // modalEl.setAttribute('aria-hidden', 'true');
        //     // modalEl.style.display = 'none';
        //     // document.body.classList.remove('modal-open');
        //     // document.body.style.removeProperty('padding-right');
        //     document.querySelectorAll('.modal-backdrop').forEach(el => el.remove());
        //     // const modalInstance = Modal.getInstance(modalEl) || new Modal(modalEl);
        //     // modalInstance.hide();
        // },
        async submitForm() {
            const formData = new FormData();
            formData.append("Name", this.name.trim());
            formData.append("Company", this.company.trim());
            formData.append("Email", this.email.trim());
            formData.append("Address", this.address.trim());
            formData.append("Active", true);
            this.$store.dispatch('postCreateClient', formData)
                .then(() => {
                    this.name = "";
                    this.company = "";
                    this.email = "";
                    this.address = "";
                })
                .catch(err => {
                    console.error('Client creation failed:', err);
                });
        }
    }
}
</script>