import Vue from 'vue'
import Vuex from 'vuex'

import store from '@/store'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    name: '',
    repos: []
  },
  getters: {
    getName(state) {
      return state.name
    },
    getRepos(state) {
      return state.repos
    },
  },
  mutations: {
    updateName(state, value) {
      localStorage.setItem("name", value)
      state.name = value
    },
    setRepos(state, value) {
      state.repos = value
    },
  },
  actions: {
    async getGithubApiRepos(context){
      $.ajax({
        url: 'https://api.github.com/search/repositories',
        dataType: 'json',
        data: {
          client_id: 'd6be03f5aad7cdfaeb6e',
          client_secret: '34352aef3b7db05016fae2b83ace417a553f586c',
          q: context.getters.getName,
          sort: 'updated',
          per_page: 10
        }
      }).done(function (repos) {
        context.commit('setRepos', repos.items);
        store.dispatch('createDBRepos');
      });
    },
    async searchDBRepos(context) {  

      let guid = localStorage.getItem("uuid");

      if(!guid){
          return;
      }          

      $.ajax({
          url: 'api/repos',
          dataType: 'json',
          data: {
            "name": context.getters.getName,
            "guid": guid
          }
      }).done(function (repos) {
          context.commit('setRepos', repos)
      });
    },    
    async createDBRepos(context){
      let repos = context.getters.getRepos;

      const response = await fetch("api/repos", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(repos)
      });
      if (response.ok === true) {
          let guid = await response.text();
          localStorage.setItem("uuid", guid)
      }
      
    }
  },
  modules: {
  }
})
