<template>
    <v-data-table :items="professors" :headers="headers">
        <template v-slot:item.actions="{ item }">
            <v-menu>
                <template v-slot:activator="{ props }">
                    <v-btn icon="mdi-dots-vertical" v-bind="props" density="compact" variant="plain"></v-btn>
                </template>
                <v-list>
                    <v-list-item @click="handleEdit(item)">
                        <template v-slot:prepend>
                            <v-icon icon="mdi-pencil"></v-icon>
                        </template>
                        <v-list-item-title>Edit</v-list-item-title>
                    </v-list-item>
                    <v-list-item @click="handleDelete(item.id)">
                        <template v-slot:prepend>
                            <v-icon icon="mdi-delete"></v-icon>
                        </template>
                        <v-list-item-title>Delete</v-list-item-title>
                    </v-list-item>
                </v-list>
            </v-menu>
        </template>
    </v-data-table>
</template>
<script setup>
import { computed, onMounted } from 'vue'
import { useStore } from 'vuex'
const store = useStore()
const professors = computed(() => store.state.professors.professors)
const headers = [
    { title: 'Name', value: 'name' },
    { title: 'Last Name', key: 'lastName' },
    { title: 'Gender', key: 'gender', value: ({ gender }) => gender == 'm' ? 'Male' : 'Female' },
    { title: 'Actions', key: 'actions' },
]

function handleEdit(student) {
    store.dispatch('professors/editProfessorDialog', student)
}


function handleDelete(id) {
    store.dispatch('professors/deleteProfessor', id)
}

</script>