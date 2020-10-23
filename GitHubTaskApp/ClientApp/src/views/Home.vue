<template>
  <div>
      <div class="container">
        <div class="searchContainer">
          <h1>Search Github Repos</h1>
          <p class="lead">Enter a name to fetch 10 latest repos</p>
          <input type="text" class="form-control" placeholder="Github Repo..." v-model="repo" @keyup="getGithubApiRepos">
        </div><br>        
        <Repo />
      </div>
  </div>
</template>

<script>
import Repo from '@/components/Repo.vue';
import { mapActions } from 'vuex'

export default {
  name: 'Home',
  components: {
    Repo
  },
  computed: {
    repo: {
      get () {
        return this.$store.state.name
      },
      set (value) {
        this.$store.commit('updateName', value)
      }
    }
  },
  methods: {
    ...mapActions([
      'getGithubApiRepos'
    ])
  }
}
</script>

