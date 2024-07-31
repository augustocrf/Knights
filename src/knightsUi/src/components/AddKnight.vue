<template>
  <div>
    <h2>Add New Knight</h2>
    <KnightForm @submit="addKnight" />
  </div>
</template>

<script>
import KnightForm from './KnightForm.vue';
import axios from '../axios';

export default {
  components: {
    KnightForm
  },
  methods: {
    async addKnight(knight) {
      try {
        await axios.post('/knights', knight);
        this.$emit('knight-added');
      } catch (error) {
        console.error('Error adding knight:', error);
      }
    }
  }
};
</script>