<template>
	<UpdateClientForm :clientId="clientId" />
</template>


<script>

import UpdateClientForm from "@/components/UpdateClientForm.vue";

export default {
	name: "Management",
	components: {
		UpdateClientForm,
	},
	data() {
		return {
			clientId: Number(this.$route.params.id),
		}
	},
	mounted() {

	}
};
</script>
