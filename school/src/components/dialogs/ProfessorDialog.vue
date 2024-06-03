<template>
    <div class="pa-4 text-center">
        <v-dialog v-model="showForm" max-width="600" :persistent="loading">
            <v-form @submit.prevent="handleSubmit()">
                <v-card :prepend-icon="selected ? 'mdi-pencil' : 'mdi-account'"
                    :title="selected ? 'Edit Professor' : 'Add Professor'">
                    <v-card-text>
                        <v-text-field v-model="form.name" label="Name*" required variant="outlined"></v-text-field>
                        <v-text-field v-model="form.lastName" label="Last Name*" required
                            variant="outlined"></v-text-field>
                        <v-select label="Gender*" v-model="form.gender" item-title="label" item-value="value"
                            :items="[{ value: 'm', label: 'Male' }, { value: 'f', label: 'Female' }]"
                            variant="outlined"></v-select>
                        <small class="text-caption text-medium-emphasis">*indicates required field</small>
                    </v-card-text>
                    <v-divider></v-divider>
                    <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn text="Close" variant="plain" @click="showForm = false" :disabled="loading"></v-btn>
                        <v-btn color="success" text="Save" variant="tonal" @click="handleSubmit"
                            :loading="loading"></v-btn>
                    </v-card-actions>
                </v-card>
            </v-form>
        </v-dialog>
    </div>
</template>

<script setup>
import { ref, computed, watch, onMounted } from 'vue'
import { useStore } from 'vuex'
import moment from 'moment'

const store = useStore()

const selected = computed(() => store.state.professors.selected)
const loading = computed(() => store.state.professors.loading)
const datepicker = ref(false)
const showForm = computed({
    get: () => store.state.professors.dialog,
    set: (value) => { store.dispatch('professors/setDialog', value); resetForm() }
})


const form = ref({
    name: '',
    lastName: '',
    gender: '',
    birthDate: new Date()
})
const resetForm = () => form.value = {
    name: '',
    lastName: '',
    gender: '',
    birthDate: new Date()
};

const dateFormated = computed(() => formatDate(form.value.birthDate))


const formatDate = (value) => moment(value).format('YYYY-MM-DD')



watch(selected, (professor) => {
    if (professor)
        form.value = { ...professor, birthDate: moment(form.value.birthDate, 'YYYY-MM-DD') }
})

const handleSubmit = async () => {
    if (selected.value)
        store.dispatch('professors/updateProfessor', { ...form.value, birthDate: formatDate(form.value.birthDate), id: selected.value.id })
    else
        store.dispatch('professors/createProfessor', { ...form.value, birthDate: formatDate(form.value.birthDate) })
    resetForm()
}
</script>