import Vue from 'vue'
import Vuex from 'vuex'

import axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
    state: {
        name: localStorage.getItem("name"),
        guid: '',
        repos: [],
        message: '',
        per_page: 10,
        client_id: process.env.VUE_APP_CLIENT_ID,
        client_secret: process.env.VUE_APP_CLIENT_SECRET
    },
    mutations: {
        UPDATE_NAME(state, payload) {
            localStorage.setItem("name", payload)
            state.name = payload
        },
        SET_GUID(state, payload) {            
            state.guid = payload
        },
        SET_REPOS(state, payload) {
            state.repos = payload
        },
        SET_MESSAGE(state, payload) {
            state.message = payload
        },
    },
    actions: {
        async getGithubRepos({ dispatch, commit, state }) {            
            try {
                const response = await axios.get("https://api.github.com/search/repositories", {
                    params: {
                        client_id: state.client_id,
                        client_secret: state.client_secret,
                        q: state.name,
                        sort: 'updated',
                        per_page: state.per_page
                    }
                })

                commit('SET_REPOS', response.data.items)

                if (response.data.items.length) {
                    commit('SET_MESSAGE', '')
                    dispatch('createDBRepos')
                } else {
                    commit('SET_MESSAGE', 'NOT FOUND')
                }
            } catch (error) {
                commit('SET_MESSAGE', 'Error occured. Try again.')
            }          
        },
        async createDBRepos({ commit, state }) {
            try {
                const response = await axios({
                    url: "/api/repos/create",
                    method: "post",
                    headers: { "content-type": "application/json" },
                    data: JSON.stringify(state.repos)
                })
                commit('SET_GUID', response.data)
                localStorage.setItem("uuid", response.data)
            } catch (error) {
                commit('SET_MESSAGE', 'Error occured. Try again.')
            }
        },
        async searchDBRepos({ commit }, key) {
            try {
                const response = await axios({
                    url: "/api/repos/search",
                    method: 'post',
                    headers: { "content-type": "application/json" },
                    data: JSON.stringify({
                        "name": key.name,
                        "uuid": key.guid
                    })                   
                })

                if (!response.data.length) {
                    commit('SET_MESSAGE', 'NOT FOUND')
                } else {
                    commit('SET_MESSAGE', '')
                }

                commit('SET_REPOS', response.data)

            } catch (error) {
                commit('SET_MESSAGE', 'Error occured. Try again.')
            }
        }
    },
    modules: {

    }
})
