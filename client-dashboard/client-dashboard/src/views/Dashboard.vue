<template>
	<div class="container">
		<ClientTable />
	</div>
</template>

<script>
//instancing and populating ClientDashboard view with API data
import ClientTable from "@/components/ClientTable.vue";

export default {
	name: "Dashboard",
	components: {
		ClientTable,
	},
	mounted() {
		let error = false;
		this.$store.commit('setTableIsLoading', true);
		this.$store.dispatch('fetchClientsDashboard')
			.catch(err => {
				error = true;
				console.error(err);
			})
			.finally(() => {
				if (error) {
					setTimeout(() => {
						this.$store.commit('setTableIsLoading', false);
					}, 3000);
				} else {
					this.$store.commit('setTableIsLoading', false);
				}
			})
	}
};
</script>
