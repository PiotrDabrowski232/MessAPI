<template>
  <Toolbar class="mb-4">
    <template #start>
      <Button label="New" icon="pi pi-plus" class="p-button-success mr-2" @click="display  =  !display" />
      <Button style="margin-left: 10px;" label="Delete" icon="pi pi-trash" class="p-button-danger"
        @click="deleteSelectedMessages" :disabled="!selectedMessages" />
    </template>
  </Toolbar>
  <div class="card">
    <DataTable :value="messages" editMode="row" dataKey="id" v-model:editingRows="editingRows"
      @row-edit-save="saveOnRowChanges" v-model:selection="selectedMessages" responsiveLayout="scroll">
      <Column selectionMode="multiple" :exportable="false"></Column>
      <Column field="id" header="ID" style="width:20%"></Column>
      <Column field="title" header="TITLE" style="width:20%">
        <template #editor="{ data, field }">
          <InputText v-model="data[field]" />
        </template>
      </Column>
      <Column field="body" header="BODY" style="width:20%">
        <template #editor="{ data, field }">
          <InputText v-model="data[field]" />
        </template>
      </Column>
      <Column :rowEditor="true" style="width:10%; min-width:8rem" bodyStyle="text-align:center"></Column>
    </DataTable>
  </div>
  <!---->
  <div class="CreateMessage" v-if="display">
    <span class="p-float-label">
      <InputText id="title" type="text" v-model="titleFromInput" />
      <label for="Title">Title</label>
    </span>
    <span class="p-float-label">
      <InputText id="body" type="text" v-model="bodyFromInput" />
      <label for="Body">Body</label>
    </span>
    <Button type="button" @click="postMessages">Post</Button>
  </div>
</template>

<script>
import DataTable from 'primevue/datatable';
import Button from 'primevue/button';
import Toolbar from 'primevue/toolbar';
import Column from 'primevue/column';
import InputText from 'primevue/inputtext';

import axios from 'axios';
export default {
  name: 'App',


  components: {
    DataTable, Column, InputText, Toolbar, Button
  },


  data() {
    return {
      editingRows: [],
      messages: null,
      selectedMessages: null,
      titleFromInput: null,
      bodyFromInput: null,
      display: false,
    }
  },



  async mounted() {
    await axios.get("https://localhost:5001/message").then(data => this.messages = data.data);
  },




  methods: {
    saveOnRowChanges(e) {
      let { newData, index } = e;
      this.messages[index] = newData;
      axios.put("https://localhost:5001/message", {
        id: this.messages[index].id,
        title: this.messages[index].title,
        body: this.messages[index].body
      })
    },

    deleteSelectedMessages() {
      for (let key in this.selectedMessages) {
        axios.delete("https://localhost:5001/message?id=" + this.selectedMessages[key].id).then(this.refreshList)
      }
      this.selectedMessages = null;
    },

    refreshList() {
      axios.get("https://localhost:5001/message").then(data => this.messages = data.data);
    },

    postMessages() {
      axios.post("https://localhost:5001/message", {
        title: this.titleFromInput,
        body: this.bodyFromInput,
      }).then(this.refreshList),
        this.titleFromInput = null,
        this.bodyFromInput = null;
      this.display = !this.display;
    },
  },
}
</script>

<style>
.CreateMessage {
  margin-top: 25px;
  margin-left: 50%;
  display: inline-flex;
  width: 100%;
}

.CreateMessage Button {
  margin-left: 11.5%;
}

.CreateMessage span:nth-child(2) {
  margin-left: 8%;
}
</style>
