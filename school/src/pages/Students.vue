<template>
    <v-container>
        <v-row>
            <v-col cols="12">
                <v-card class="py-4" rounded="lg" variant="tonal">
                    <template #title>
                        <h2 class="text-h4 font-weight-light pb-4">Students</h2>
                    </template>

                    <div class="mx-4 d-flex flex-row-reverse">
                        <v-btn class="rounded-xl px-4" @click="openDialog()" prepend-icon="mdi-plus" color="success"
                            variant="tonal">
                            Add Student
                        </v-btn>
                    </div>

                    <div class="ma-4">
                        <StudentTable class="rounded-lg" />
                    </div>
                </v-card>
            </v-col>
        </v-row>
        <StudentDialog></StudentDialog>
    </v-container>
</template>

<script setup>
import { computed, onMounted } from "vue"
import { useStore } from "vuex"

const store = useStore()
const students = computed(store.state.students.students)

function openDialog() {
    store.dispatch("students/addStudentDialog")
}

onMounted(() => {
    store.dispatch("students/fetchStudents")
})
</script>