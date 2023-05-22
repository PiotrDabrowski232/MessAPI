<template>

      <ToolBar class="mb-4">

            <template #start>

              <ButtonBase label="New" icon="pi pi-plus" class="p-button-success mr-2" @click="display  =  !display" />
              <ButtonBase style="margin-left: 10px;" label="Delete" icon="pi pi-trash" class="p-button-danger"
                @click="deleteSelectedMessages" :disabled="!selectedMessages" />

            </template>

      </ToolBar>

  <div class="card">

        <DataTable :value="messages" editMode="row" dataKey="id" v-model:editingRows="editingRows"
          @row-edit-save="saveOnRowChanges" v-model:selection="selectedMessages" responsiveLayout="scroll">

              <ColumnTable selectionMode="multiple" :exportable="false"></ColumnTable>

              <ColumnTable field="id" header="ID" style="width:20%"></ColumnTable>

              <ColumnTable field="title" header="TITLE" style="width:20%">
                    <template #editor="{ data, field }">
                      <InputText v-model="data[field]" />
                    </template>
              </ColumnTable>

              <ColumnTable field="body" header="BODY" style="width:20%">
                    <template #editor="{ data, field }">
                      <InputText v-model="data[field]" />
                    </template>
              </ColumnTable>

              <ColumnTable field="type" header="TYPE OF MESSAGE" style="width:20%"></ColumnTable>

              <ColumnTable :rowEditor="true" style="width:10%; min-width:8rem" bodyStyle="text-align:center"></ColumnTable>

        </DataTable>

  </div>

    <ToastToast/>

        <DialogInput class="input-dialog" v-model:visible="display" modal header="Input Data" :style="{ width: '25vw', height:'45vh' }">
                  
                              <span class="p-float-label">
                                <InputText class="text" id="title" type="text" v-model="titleFromInput" required/>
                                <label for="Title">Title</label>
                              </span>

                              <span class="p-float-label">
                                <InputText id="body" type="text" v-model="bodyFromInput" />
                                <label for="Body">Body</label>
                              </span>
                      
                              <div class="flex flex-wrap gap-3">

                                <p style="margin-left: 7VW; margin-top: 20px;">Type:</p>

                                <div class="flex-align-items-center">
                                    <RadioButton v-model="type" inputId="Type1" name="type" value="Positive" />
                                    <label for="Type1" class="ml-2">Positive</label>
                                </div>

                                <div class="flex-align-items-center">
                                    <RadioButton v-model="type" inputId="Type2" name="pizza" value="Negative" />
                                    <label for="Type2" class="ml-2">Negative</label>
                                </div>

                                <div class="flex-align-items-center">
                                    <RadioButton v-model="type" inputId="Type3" name="pizza"  value="Neutral" />
                                    <label for="Type3" class="ml-2">Neutral</label>
                                </div>

                              </div>

                  <ButtonBase style="bottom: 10px; right: 12px; position: absolute; " type="button" @click="postMessages">Accept</ButtonBase>
                  
        </DialogInput>

</template>

<script>


import axios from 'axios';


export default {
  name: 'App',


  data() {
    return {
      editingRows: [],
      messages: null,
      selectedMessages: null,
      titleFromInput: null,
      bodyFromInput: null,
      type: "Neutral",
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
      }),
      this.$toast.add({ severity: 'success', summary: 'Success ', detail: `Message: ${this.messages[index].id} updated`, life: 3000 });
    },

    deleteSelectedMessages() {
      for (let key in this.selectedMessages) {
        axios.delete("https://localhost:5001/message?id=" + this.selectedMessages[key].id).then(this.refreshList)
      }
      this.selectedMessages = null;
      this.$toast.add({ severity: 'warn', summary: 'Warning', detail: 'Message(s) Deleted', life: 3000 });
    },

    refreshList() {
      axios.get("https://localhost:5001/message").then(data => this.messages = data.data);
    },

    postMessages() {
      if(this.titleFromInput==null || this.bodyFromInput==null || this.titleFromInput=="" || this.bodyFromInput==""){
        this.$toast.add({ severity: 'error', summary: 'Error Message', detail: 'Complete all fields', life: 3000 });
      }else{
      axios.post("https://localhost:5001/message", {
        title: this.titleFromInput,
        body: this.bodyFromInput,
        type: this.type
      }).then(this.refreshList),
      this.$toast.add({ severity: 'success', summary: 'Success', detail: `Message Added`, life: 3000 });
      console.log(this.type)
        this.titleFromInput = null,
        this.bodyFromInput = null;
        this.type= "Neutral",
      this.display = !this.display;
    }},
  },
}
</script>

<style>
.input-dialog{
  text-align: left;
}
.input-dialog  span, .flex-align-items-center{
  margin-top: 24px;
  margin-left: 7VW;
}

.p-dialog .p-dialog-content:last-of-type {
    border-bottom-right-radius: 3px;
    border-bottom-left-radius: 3px;
    height: 77%;
}
</style>
