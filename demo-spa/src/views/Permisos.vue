<template>
    <div>
        <v-card
            height="500px"
            width="800px"
            class="mx-auto"
            centered
        >
            <v-card-title primary-title>
                <h3>Permisos</h3> 
            </v-card-title>
            <v-layout align-end justify-end>
                <v-card-actions align-end justify-end>
                    <v-btn color="primary" @click="dialog = true">Add new</v-btn>
                </v-card-actions>
            </v-layout>
        </v-card>
        <v-dialog
            v-model="dialog"
            width="500"
        >
            <v-card>
                <v-card-title class="headline grey lighten-2">
                    Agrega nuevo permiso
                </v-card-title>

                <v-card-text>
                    <v-form>
                        <v-row>
                            <v-col cols="12" sm="12" md="12">
                                <v-text-field label="Nombre del empleado" required></v-text-field>
                            </v-col>
                            <v-col cols="12" sm="12" md="12">
                                <v-text-field label="Apellido del empleado" hint="No dejar emplaco"></v-text-field>
                            </v-col>                            
                            <v-col cols="12" sm="12">
                                <v-select
                                :items="permisos"
                                label="Tipo de permiso"
                                required
                                ></v-select>
                            </v-col>
                        </v-row>
                    </v-form>
                
                </v-card-text>

                <v-divider></v-divider>

                <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn
                    color="primary"
                    text
                    @click="dialog = false"
                >
                    I accept
                </v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </div>
</template>

<script>
export default {
    data: () => ({
        dialog: false,
        permisos: []
    })
}
</script>