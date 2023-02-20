<template>
  <div>
    <div class="grid">
      <div class="text-center">
        <h5>{{ horarioAtual }}</h5>
      </div>
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
      <template template v-slot:default>
        <b-form-group
          label="Placa do carro"
          description="Ex: ABC-1234 ou ABC-1D34"
          label-for="input-registro"
          :state="placaValida"
          :validated="false"
          :invalid-feedback="invalidFeedback"
        >
          <b-form-input
            v-model="registro.placaCarro"
            id="input-registro"
            :state="placaValida"
            maxlength="8"
          >
          </b-form-input>
        </b-form-group>
      </template>
      <template template v-slot:footer>
        <button class="btn btn-light" @click="fecharModal">Sair</button>
        <button
          class="btn btn-success"
          @click="registrarPonto"
          :disabled="!permitirMarcar"
        >
          Marcar
        </button>
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

    const buscarDados = () =>
      api.getAll().then((payload) => {
        data.value = payload.data;
      });

    buscarDados();

    const checkZero = (data) => {
      if (data.length == 1) {
        data = "0" + data;
      }
      return data;
    };

    const gerarHorario = () => {
      var today = new Date();
      var day = today.getDate() + "";
      var month = today.getMonth() + 1 + "";
      var year = today.getFullYear() + "";
      var hour = today.getHours() + "";
      var minutes = today.getMinutes() + "";
      var seconds = today.getSeconds() + "";

      day = checkZero(day);
      month = checkZero(month);
      year = checkZero(year);
      hour = checkZero(hour);
      minutes = checkZero(minutes);
      seconds = checkZero(seconds);

      return (
        day +
        "/" +
        month +
        "/" +
        year +
        " " +
        hour +
        ":" +
        minutes +
        ":" +
        seconds
      );
    };

    let horarioAtual = ref(gerarHorario());

    setInterval(() => {
      horarioAtual.value = gerarHorario();
    }, 1000);

    const registro = ref({ placaCarro: "" });

    const placaValida = computed(() => registro.value.placaCarro.length >= 8);

    const invalidFeedback = computed(() =>
      registro.value.placaCarro.length > 0
        ? "Placa incompleta"
        : "Informe a placa do carro"
    );

    const marcarEntrada = ref(true);

    const permitirMarcar = ref(true);

    const modalAberta = ref(false);

    const abrirModal = (entrada) => {
      registro.value.placaCarro = "";
      modalAberta.value = true;
      marcarEntrada.value = entrada;
    };

    const fecharModal = () => (modalAberta.value = false);

    const registrarPonto = () => {
      if (placaValida.value) {
        permitirMarcar.value = false;
        if (marcarEntrada.value) {
          registro.value.horarioEntrada = gerarHorario();
          registro.value.horarioSaida = null;
        } else {
          registro.value.horarioSaida = gerarHorario();
          registro.value.horarioEntrada = null;
        }
        const request = marcarEntrada.value
          ? api.marcarEntrada(registro.value)
          : api.marcarSaida(registro.value);
        request
          .then(() => {
            buscarDados();
            permitirMarcar.value = true;
            fecharModal();
          })
          .catch((err) => {
            alert(err.message);
            permitirMarcar.value = true;
          });
      }
    };

    return {
      columns,
      data,
      horarioAtual,
      registro,
      placaValida,
      invalidFeedback,
      marcarEntrada,
      modalAberta,
      permitirMarcar,
      abrirModal,
      fecharModal,
      registrarPonto,
    };
  },
};
</script>
