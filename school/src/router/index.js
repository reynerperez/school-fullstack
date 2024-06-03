import Grades from '@/pages/Grades.vue'
import Layout from '@/pages/Layout.vue'
import Professors from '@/pages/Professors.vue'
import Students from '@/pages/Students.vue'
import { createRouter, createWebHistory } from 'vue-router/auto'

const router = createRouter({
  history: createWebHistory(),
  routes: [
    {
      path: "/",
      redirect: { path: "/students" },
      component: Layout,
      children: [
        {
          name: 'students',
          path: '/students',
          component: Students
        },
        {
          name: 'professors',
          path: '/professors',
          component: Professors
        },
        {
          name: 'grades',
          path: '/grades',
          component: Grades
        }
      ]
    }
  ]
})

export default router
