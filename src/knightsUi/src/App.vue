<template>
  <div id="app">
    <KnightsList @edit-knight="editKnight" @knight-deleted="fetchKnights" />
    <AddKnight @knight-added="fetchKnights" v-if="!isEditing" />
    <EditKnight :knight="selectedKnight" @knight-updated="finishEditing" v-if="isEditing" />
  </div>
</template>

<script>
import KnightsList from './components/KnightsList.vue';
import AddKnight from './components/AddKnight.vue';
import EditKnight from './components/EditKnight.vue';

export default {
  components: {
    KnightsList,
    AddKnight,
    EditKnight
  },
  data() {
    return {
      isEditing: false,
      selectedKnight: null
    };
  },
  methods: {
    fetchKnights() {
      this.$refs.knightsList.fetchKnights();
    },
    editKnight(knight) {
      this.selectedKnight = knight;
      this.isEditing = true;
    },
    finishEditing() {
      this.isEditing = false;
      this.selectedKnight = null;
      this.fetchKnights();
    }
  }
};
</script>