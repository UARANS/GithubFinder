<template>
    <div>
        <div class="card border-primary mb-3" 
            style="max-width: 100rem;" 
            v-for="repo in getRepos" 
            :key="repo.id">
          <div class="card-header"><h3>{{repo.owner.login}}</h3></div>
          <div class="card-body">
            <div class="row">
            <div class="col-md-3">
              <img class="img-thumbnail avatar" :src="repo.owner.avatar_url">
              <a target="_blank" class="btn btn-primary btn-block" :href="repo.html_url">Repo Page</a>
            </div>
            <div class="col-md-9">
                <div class="badge badge-dark">Forks: {{repo.forks_count}}</div>                    
                <div class="badge badge-success">Stars: {{repo.stargazers_count}}</div>
              <br><br>
              <ul class="list-group">
                <li class="list-group-item"><span class="repo">Repo Name: </span>{{repo.name}}</li>
                <li class="list-group-item">Description: {{repo.description}}</li>
                <li class="list-group-item">Languages: {{repo.language}}</li>
                <li class="list-group-item">Updated: {{repo.updated_at}}</li>
              </ul>
              </div>
            </div>
          </div>
        </div>        
    </div>
</template>

<script>
import { mapGetters } from 'vuex';
import { mapActions } from 'vuex';

export default {
    computed: {
        ...mapGetters(['getRepos']), 
    },
    created: function () {
        this.retrieveRepos();
    },
    methods: {
        ...mapActions([
            'searchDBRepos'
        ]),
        retrieveRepos: function () {
            if (localStorage.getItem("name")) {    
                let name = localStorage.getItem("name");
                this.$store.commit('updateName', name)        
                this.searchDBRepos();
            }
        }
    }
}
</script>

<style scoped>
    .avatar {
        width: 100%
    }
    .badge{
        margin: 0 5px;
    }
    .repo{
        font-weight: bold;
    }
</style>