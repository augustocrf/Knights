<template>
  <div>
    <h1>Knights List</h1>
    <ul>
      <li v-for="knight in knights" :key="knight.id">
        {{ knight.name }} - {{ knight.heroClass }}
        <button @click="editKnight(knight)">Edit</button>
        <button @click="deleteKnight(knight.id)">Delete</button>
      </li>
    </ul>
    <p v-if="errorMessage" class="error">{{ errorMessage }}</p>
  </div>
</template>

<script>
import axios from '../axios';

export default {
  data() {
    return {
      knights: [],
      errorMessage: ''
    };
  },
  created() {
    this.fetchKnights();
  },
  methods: {
    async fetchKnights() {
      try {
        const response = await axios.get('/knights');
        this.knights = response.data;
      } catch (error) {
        this.handleError(error);
      }
    },
    async deleteKnight(id) {
      try {
        await axios.delete(`/knights/${id}`);
        this.fetchKnights();
      } catch (error) {
        this.handleError(error);
      }
    },
    editKnight(knight) {
      this.$emit('edit-knight', knight);
    },
    handleError(error) {
      this.errorMessage = error.response && error.response.data.message ? error.response.data.message : 'An error occurred';
    }
  }
};
</script>

<style>
.error {
  color: red;
}
</style>