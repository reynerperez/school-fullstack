<template>
    <v-container>
        <v-row>
            <v-col cols="12">
                <v-card class="py-4" rounded="lg" variant="tonal">
                    <template #title>
                        <h2 class="text-h4 font-weight-light pb-4">Professors</h2>
                    </template>

                    <div class="mx-4 d-flex flex-row-reverse">
                        <v-btn class="rounded-xl px-4" @click="openDialog()" prepend-icon="mdi-plus" color="success"
                            variant="tonal">
                            Add Professor
                        </v-btn>
                    </div>

                    <div class="ma-4">
                        <ProfessorTable class="rounded-lg" />
                    </div>
                </v-card>
            </v-col>
        </v-row>
        <ProfessorDialog />
    </v-container>
</template>

<script setup>
import { computed, onMounted } from "vue"
import { useStore } from "vuex"

const store = useStore()
const professors = computed(store.state.professors.professors)

function openDialog() {
    store.dispatch("professors/addProfessorDialog")
}

onMounted(() => {
    store.dispatch("professors/fetchProfessors")
})
</script>