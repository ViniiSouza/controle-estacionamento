<template>
  <div class="grid">
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
      <b-col cols="1" class="grid-body-column">{{ registro.placaCarro }}</b-col>
      <b-col cols="2" class="grid-body-column">{{ registro.horarioEntrada }}</b-col>
      <b-col cols="2" class="grid-body-column">{{ registro.horarioSaida }}</b-col>
      <b-col cols="2" class="grid-body-column">{{ registro.duracao }}</b-col>
      <b-col cols="2" class="grid-body-column">{{ registro.tempoCobrado }}</b-col>
      <b-col cols="1" class="grid-body-column">{{ registro.valorHora }}</b-col>
      <b-col cols="2" class="grid-body-column">{{ registro.valorTotal }}</b-col>
    </b-row>
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
export default {
  data() {
    return {
      columns: [
        { text: "Placa", cols: "1" },
        { text: "Horário de Chegada", cols: "2" },
        { text: "Horário de Saída", cols: "2" },
        { text: "Duração", cols: "2" },
        { text: "Tempo Cobrado (hora)", cols: "2" },
        { text: "Preço", cols: "1" },
        { text: "Valor a Pagar", cols: "2" },
      ],
      data: [
        {
          id: 1,
          placaCarro: "ABC1234",
          horarioEntrada: "10/10/2010 08:43:25",
          horarioSaida: "10/10/2010 09:43:25",
          duracao: "1:00:00",
          tempoCobrado: 1,
          valorHora: "R$ 2,00",
          valorTotal: "R$ 2,00",
        },
        {
          id: 1,
          placaCarro: "ABC1234",
          horarioEntrada: "10/10/2010 08:43:25",
          horarioSaida: "10/10/2010 09:43:25",
          duracao: "1:00:00",
          tempoCobrado: 1,
          valorHora: "R$ 2,00",
          valorTotal: "R$ 2,00",
        },{
          id: 1,
          placaCarro: "ABC1234",
          horarioEntrada: "10/10/2010 08:43:25",
          horarioSaida: "10/10/2010 09:43:25",
          duracao: "1:00:00",
          tempoCobrado: 1,
          valorHora: "R$ 2,00",
          valorTotal: "R$ 2,00",
        },{
          id: 1,
          placaCarro: "ABC1234",
          horarioEntrada: "10/10/2010 08:43:25",
          horarioSaida: "10/10/2010 09:43:25",
          duracao: "1:00:00",
          tempoCobrado: 1,
          valorHora: "R$ 2,00",
          valorTotal: "R$ 2,00",
        },
      ],
    };
  },
};
</script>
