import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";
const CLIENT_API_URL = "http://localhost:5000/api/client";

const clientAPI = axios.create({
  baseURL: CLIENT_API_URL,
  headers: {
    "Content-Type": "application/json",
  },
});

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    // Indicates whether the user has previously attempted to log in during this browser tab session.
    // Prevents redirecting back to the login page unless the sessionStorage flag is cleared.
    hasAttemptedLogin: sessionStorage.getItem("hasAttemptedLogin") === "true",

    // Holds the full list of client records fetched from the backend.
    // Used to render the ClientTable on the dashboard.
    clientList: [],

    // Temporarily stores the most recently created client at the top of the dashboard.
    // Used to pin and prioritize new entries visually in the UI.
    topClient: null,

    // Flag for UI components to indicate when the client table is in a loading state.
    // Controls loading indicators on the dashboard.
    tableIsLoading: true,
  },
  mutations: {
    markLoginAttempt(state) {
      state.hasAttemptedLogin = true;
    },
    setClientList(state, data) {
      state.clientList = data;
    },
    setTopClient(state, data) {
      state.topClient = data;
    },
    setTableIsLoading(state, data) {
      state.tableIsLoading = data;
    },
  },
  actions: {
    /**
     * Fetches a specific client by ID.
     * No mutations committed as the data is returned for direct usage.
     */
    async fetchClientById({ commit }, id) {
      try {
        const res = await clientAPI.get("/" + id);
        return res;
      } catch (err) {
        throw err;
      }
    },

    /**
     * Fetches all clients from the server and commits them to the store.
     * not used but kept just in case.
     */
    async fetchAllClients({ commit }) {
      try {
        const res = await clientAPI.get("/dashboard");
        commit("setClientList", res.data);
        return res;
      } catch (err) {
        throw err;
      }
    },

    /**
     * Fetches dashboard client data and resets the topClient to null.
     * Useful when refreshing or after state-altering operations.
     */
    async fetchClientsDashboard({ commit }) {
      try {
        const res = await clientAPI.get("/dashboard");
        commit("setClientList", res.data);
        commit("setTopClient", null);

        return res;
      } catch (err) {
        throw err;
      }
    },

    /**
     * Creates a new client using formData. If a topClient exists,
     * the dashboard client list is refreshed before creation.
     * Sets the newly created client as the topClient.
     */
    async postCreateClient({ commit, dispatch, state }, formData) {
      try {
        if (state.topClient) {
          await dispatch("fetchClientsDashboard");
        }
        const res = await clientAPI.post("/create", formData);
        commit("setTopClient", res.data);
        return res;
      } catch (err) {
        throw err;
      }
    },

    /**
     * Updates an existing client.
     * No mutations committed as the caller typically handles local state.
     */
    async putUpdateClient({ commit }, formData) {
      try {
        const res = await clientAPI.put("/update", formData);
        return res;
      } catch (err) {
        throw err;
      }
    },

    /**
     * Archives a client by ID.
     * No mutations committed as state is expected to be refreshed after.
     */
    async postArchiveClientById({ commit }, id) {
      try {
        const res = await clientAPI.post("/archive/" + id);
        return res;
      } catch (err) {
        throw err;
      }
    },
  },
  modules: {},
});
