<template>
    <v-list density="compact" nav>
        <v-list-item v-for="item in items" ::key="item.title" :prepend-icon="item.icon" :to="{ name: item.routeName }"
            :title="item.title"></v-list-item>
    </v-list>
</template>

<script setup>
import { ref } from 'vue'

const items = ref([
    { icon: 'mdi-account', routeName: 'students', title: 'Students' },
    { icon: 'mdi-school', routeName: 'professors', title: 'Professors' },
    { icon: 'mdi-book', routeName: 'grades', title: 'Grades' }
])

</script>