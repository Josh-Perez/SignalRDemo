<script setup>
import { ref, onMounted } from 'vue';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';

const offers = ref([]);

onMounted(() => {
  const hubConnectionBuilder = new HubConnectionBuilder().withUrl('https://localhost:7039/offers')
  .configureLogging(LogLevel.Information).build();

  hubConnectionBuilder.start().then(() => {
    console.log('Connection started.....!');
  }).catch(err => console.log('Error while starting connection: ' + err));

  hubConnectionBuilder.on('SendOffersToUser', (result) => {
    offers.value.push(result);
  });
});
</script>

<template>
  <div v-if="offers.length > 0">
    <ul>
      <li v-for="(offer, index) in offers">
        Offers: <b>{{ offer.join(', ') }}</b>
      </li>
    </ul>
  </div>
</template>

<style scoped>
.read-the-docs {
  color: #888;
}
</style>
