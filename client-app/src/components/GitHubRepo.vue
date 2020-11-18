<template>
    <section>
        <div v-show="message" class="alert alert-danger">{{ message }}</div>
        <div class="card border-primary mb-3"
             style="max-width: 100rem;"
             v-for="repo in repos"
             :key="repo.id">
            <div class="card-header"><h3>{{ repo.owner.login }}</h3></div>
            <div class="card-body">
                <div class="row">
                    <div class="col-md-3">
                        <img class="img-thumbnail avatar" :src="repo.owner.avatar_url">
                        <a target="_blank" class="btn btn-primary btn-block" :href="repo.html_url">Repo Page</a>
                    </div>
                    <div class="col-md-9">
                        <div class="badge badge-dark">Forks: {{ repo.forks_count }}</div>
                        <div class="badge badge-success">Stars: {{ repo.stargazers_count }}</div>
                        <br><br>
                        <ul class="list-group">
                            <li class="list-group-item"><span class="repo">Repo Name: </span>{{ repo.name }}</li>
                            <li class="list-group-item">Description: {{ repo.description }}</li>
                            <li class="list-group-item">Languages: {{ repo.language }}</li>
                            <li class="list-group-item">Updated: {{ repo.updated_at | toLocaleString }}</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>       
    </section>
</template>

<script>
    import { mapState, mapActions } from 'vuex';

    export default {
        computed: {
            ...mapState([
                'name',
                'guid',
                'repos',
                'message'
            ])
        },
        created () {
            this.getDBRepos()
        },
        methods: {
            ...mapActions([
                'searchDBRepos'
            ]),
            getDBRepos() {
                let name = localStorage.getItem("name")
                let guid = localStorage.getItem("uuid")

                if (name && guid) {
                    this.searchDBRepos({
                        name: name,
                        guid: guid
                    })
                }
            }
        },
        filters: {
            toLocaleString (value) {
                if (!value) return ''
                value = new Date(value)
                return value.toLocaleString()
            }
        }
    }
</script>

<style scoped>
    .avatar {
        width: 100%;
        margin-bottom: 10px;
    }

    .badge {
        margin: 0 5px;
    }

    .repo {
        font-weight: bold;
    }
</style>