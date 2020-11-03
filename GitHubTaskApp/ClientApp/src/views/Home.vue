<template>
    <div class="container">
        
        <div class="searchContainer">
            <h1>Search Github Repos</h1>
            <p class="lead">Enter a name to fetch 10 latest repos</p>
            <input type="text" class="form-control" placeholder="Github Repo..." v-model.trim="repo" >
        </div>
        
        <br>
        
        <GitHubRepo />
    </div>
</template>

<script>
    import GitHubRepo from '@/components/GitHubRepo.vue';

    import { mapState, mapActions } from 'vuex'
    import { debounce } from 'lodash'

    export default {
        name: 'Home',
        components: {
            GitHubRepo
        },
        created () {
            this.debouncedGetRepos = debounce(this.getGithubRepos, 1000)
        },
        computed: {
            ...mapState([
                'name',
                'loading'
            ]),
            repo: {
                get() {
                    return this.name
                },
                set(value) {
                    this.$store.commit('UPDATE_NAME', value)
                }
            }
        },
        methods: {
            ...mapActions([
                'getGithubRepos'
            ])
        },
        watch: {
            repo() {
                if (!this.name) return
                this.debouncedGetRepos()
            }
        }
    }
</script>

