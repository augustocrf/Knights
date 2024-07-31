<template>
  <form @submit.prevent="handleSubmit">
    <div>
      <label for="name">Name:</label>
      <input type="text" v-model="form.name" required />
    </div>
    <div>
      <label for="heroClass">Hero Class:</label>
      <input type="text" v-model="form.heroClass" required />
    </div>
    <div>
      <label for="powers">Powers (comma-separated):</label>
      <input type="text" v-model="form.powers" />
    </div>
    <div>
      <label for="weapons">Weapons (comma-separated):</label>
      <input type="text" v-model="form.weapons" />
    </div>
    <div>
      <label for="attributes">Attributes (format: key=value, comma-separated):</label>
      <input type="text" v-model="form.attributes" />
    </div>
    <button type="submit">Submit</button>
  </form>
</template>

<script>
export default {
  props: {
    knight: {
      type: Object,
      default: () => ({
        name: '',
        heroClass: '',
        powers: '',
        weapons: '',
        attributes: ''
      })
    }
  },
  data() {
    return {
      form: { ...this.knight }
    };
  },
  methods: {
    handleSubmit() {
      const formattedKnight = {
        ...this.form,
        powers: this.form.powers.split(',').map(s => s.trim()),
        weapons: this.form.weapons.split(',').map(s => s.trim()),
        attributes: Object.fromEntries(this.form.attributes.split(',').map(attr => {
          const [key, value] = attr.split('=').map(s => s.trim());
          return [key, parseInt(value, 10)];
        }))
      };
      this.$emit('submit', formattedKnight);
    }
  }
};
</script>