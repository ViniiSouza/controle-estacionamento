<template>
  <div>
    <div class="grid">
      <div class="d-flex justify-content-end">
        <button
          class="btn btn-outline-success mx-2 mb-2"
          @click="abrirModal(true)"
        >
          Marcar entrada
        </button>
        <button class="btn btn-outline-danger mb-2" @click="abrirModal(false)">
          Marcar saída
        </button>
      </div>
      <b-row class="grid-header">
        <b-col
          v-for="column in columns"
          :key="column.text"
          :cols="column.cols"
          class="grid-header-column"
          >{{ column.text }}</b-col
        >
      </b-row>
      <b-row class="grid-body-row" v-for="registro in data" :key="registro.id">
        <b-col cols="1" class="grid-body-column">{{
          registro.placaCarro
        }}</b-col>
        <b-col cols="2" class="grid-body-column">{{
          registro.horarioEntrada
        }}</b-col>
        <b-col cols="2" class="grid-body-column">{{
          registro.horarioSaida
        }}</b-col>
        <b-col cols="2" class="grid-body-column">{{ registro.duracao }}</b-col>
        <b-col cols="2" class="grid-body-column">{{
          registro.tempoCobrado
        }}</b-col>
        <b-col cols="1" class="grid-body-column"
          >R$ {{ registro.valorHora }}</b-col
        >
        <b-col cols="2" class="grid-body-column">{{
          registro.valorTotal ? `R$ ${registro.valorTotal}` : ""
        }}</b-col>
      </b-row>
    </div>
    <b-modal v-model="modalAberta">
      <template v-slot:header
        >Marcar {{ marcarEntrada ? "entrada" : "saída" }}</template
      >
      <template template v-slot:footer>
        <button class="btn btn-light" @click="fecharModal">Sair</button>
        <button class="btn btn-success">Marcar</button>
      </template>
      <template template v-slot:default>
        <b-form-group
          label="Placa do carro"
          description="Ex: ABC-1234"
          label-for="input-registro"
          :state="placaValida"
          :validated="false"
          :invalid-feedback="invalidFeedback"
        >
          <b-form-input
            v-model="placaCarro"
            id="input-registro"
            :state="placaValida"
            maxlength="8"
          >
          </b-form-input>
        </b-form-group>
      </template>
    </b-modal>
  </div>
</template>
<style>
.grid {
  width: 80%;
  min-height: 70vh;
  margin: 2vh auto;
  padding: 10px;
  border-radius: 5px;
}
.grid-header-column {
  border-right: 1px solid grey;
  border-top: 1px solid grey;
  border-bottom: 1px solid grey;
  background-color: rgb(19, 0, 126);
  color: white;
  font-weight: bold;
  text-align: center;
  height: 4vh;
  padding-top: 7px;
}
.grid-header-column:first-child {
  border-left: 1px solid grey;
}
.grid-body-row {
}
.grid-body-column {
  border-right: 1px solid grey;
  border-bottom: 1px solid grey;
  height: 4vh;
  text-align: center;
  padding-top: 5px;
}
.grid-body-column:first-child {
  border-left: 1px solid grey;
}
</style>
<script>
import api from "./services/api";
import { computed, ref } from "vue";

export default {
  created() {
    api.getAll().then((payload) => {
      this.data = payload.data;
    });
  },
  setup() {
    const columns = ref([
      { text: "Placa", cols: "1" },
      { text: "Horário de Chegada", cols: "2" },
      { text: "Horário de Saída", cols: "2" },
      { text: "Duração", cols: "2" },
      { text: "Tempo Cobrado (hora)", cols: "2" },
      { text: "Preço", cols: "1" },
      { text: "Valor a Pagar", cols: "2" },
    ]);
    const data = ref([]);

    const placaCarro = ref("");

    const placaValida = computed(() => placaCarro.value.length >= 8);

    const invalidFeedback = computed(() =>
      placaCarro.value.length > 0 ? 'Placa incompleta' : 'Informe a placa do carro'
    )

    const marcarEntrada = ref(true);

    const modalAberta = ref(false);

    const abrirModal = (entrada) => {
      placaCarro.value = "";
      modalAberta.value = true;
      marcarEntrada.value = entrada;
    };

    const fecharModal = () => (modalAberta.value = false);

    return {
      columns,
      data,
      placaCarro,
      placaValida,
      invalidFeedback,
      marcarEntrada,
      modalAberta,
      abrirModal,
      fecharModal,
    };
  },
};
</script>
