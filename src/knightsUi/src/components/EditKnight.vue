<template>
  <div>
    <h2>Edit Knight</h2>
    <KnightForm :knight="knight" @submit="updateKnight" />
  </div>
</template>

<script>
import KnightForm from './KnightForm.vue';
import axios from '../axios';

export default {
  components: {
    KnightForm
  },
  props: {
    knight: {
      type: Object,
      required: true
    }
  },
  methods: {
    async updateKnight(updatedKnight) {
      try {
        await axios.put(`/knights/${updatedKnight.id}`, updatedKnight);
        this.$emit('knight-updated');
      } catch (error) {
        console.error('Error updating knight:', error);
      }
    }
  }
};
</script>