<template>
  <v-app>
    <v-dialog v-model="showDialog" persistent max-width="450px">
      <v-card class="mx-auto">
        <template v-slot:title>
          <v-row no-gutters justify="start">
              <v-icon color="green darken-1" class="mr-2"> mdi mdi-key </v-icon>
              <div>{{ $t('messages.accessCode_Title') }} </div>
            </v-row>
          
        </template>
        <v-card-text>
          <v-divider />

          <br />

          <v-col class="pa-0">
            <v-text-field @keydown.enter="verifyAccessCode()" v-model="accessCode" hint="Zugangscode = 4 Nummern" counter clearable :label="$t('labels.accessCode')" type="text" :rules="rules" maxlength="4" inputmode="numeric" pattern="\d*" />
            <div v-if="isCodeInvalid" class="text-error text-center">!!! Code Falsch !!!</div>
          </v-col>

          <br />

          <p class="text-block" v-html="$t('messages.accessCode_SubTitle')"></p>

          <br />
          <v-divider />
          <br />

          <h3>{{ $t('messages.accessCode_Info') }}</h3>
          <v-container>
            <v-row no-gutters>
              <v-col cols="1"> <v-icon> mdi mdi-menu-right </v-icon></v-col>
              <v-col> {{ $t('messages.accessCode_InfoDesc1') }} </v-col>
            </v-row>
            <v-row no-gutters>
              <v-col cols="1"> <v-icon> mdi mdi-menu-right </v-icon></v-col>
              <v-col> {{ $t('messages.accessCode_InfoDesc2') }} </v-col>
            </v-row>
            <v-row>
              <v-col cols="1"> <v-icon color="green darken-1"> mdi mdi-security </v-icon></v-col>
              <v-col> {{ $t('messages.accessCode_InfoDesc3') }} </v-col>
            </v-row>
          </v-container>
          
          <br />
          <v-divider />
        </v-card-text>

        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="green darken-1" :disabled="!accessCode || accessCode.length !== 4 || !/^\d*$/.test(this.accessCode)" variant="tonal" @click="verifyAccessCode()" prepend-icon="mdi-check">{{ $t('labels.confirm') }}</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
    <v-main>
      <router-view />
    </v-main>
  </v-app>
</template>

<script>
export default {
  data() {
    return {
      showDialog: false,
      accessCode: '',
      isCodeInvalid: false,
      rules: [(value) => !!value || this.$t('validation.generic_necessary'), (value) => /^\d*$/.test(value) || this.$t('validation.numbers_only')],
    };
  },

  mounted() {
    this.showDialog = true;
  },

  methods: {
    verifyAccessCode() {
      if (this.accessCode.length !== 4 || !/^\d*$/.test(this.accessCode)) return;

      this.isCodeInvalid = false;

      if (this.accessCode === '1234') {
        this.showDialog = false;
      } else {
        this.isCodeInvalid = true;
      }
    },
  },
};
</script>

<style scoped>
.text-block {
  hyphens: auto;
  white-space: pre-line;
  text-align: justify;
}
</style>
