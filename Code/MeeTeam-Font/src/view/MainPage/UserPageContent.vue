<template>
    <div id="bigbox">
        <div>
            <el-row :gutter="10">
                <el-col :span="12">
                    <el-card class="box-card">
                        <template #header>
                            <div class="card-header">
                                <span>hi, {{ user_name }} !</span>
                                <!--span标签用于组合行内的元素-->
                            </div>
                        </template>
                        <template>
                            <el-calendar v-model="value" />
                        </template>
                    </el-card>
                </el-col>

                <el-col :span="12">
                    <el-card class="box-card">
                        <template #header>
                            <div class="card-header">
                                <span>近期公告速览</span>
                                <!--span标签用于组合行内的元素-->
                                <el-button type=primary class="button" text>For More</el-button>
                            </div>
                        </template>
                        <div v-for="o in 4" :key="o" class="text item">{{ 'List item ' + o }}</div>
                    </el-card>
                </el-col>
            </el-row>
        </div>

        <br>
        <h3 style="text-align:left">近期热点项目</h3>

        <template>
            <div class="light_index">
                <!--跑马灯-->
                <div>
                    <el-carousel :interval="4000" type="card" height="200px">
                        <el-carousel-item v-for="item in imageList" :key="item.id">
                            <img :src="item.idView" class="image">
                        </el-carousel-item>
                    </el-carousel>
                </div>
            </div>
        </template>

    </div>

</template>


<script>
import global_msg from '../../utils/global.js'
import { getInfo } from '@/api/getinfo';
import { ref } from 'vue'
const value = ref(new Date())

export default {
    name: '_index',
    data() {
        return {
            user_name: '',
            user_id: '',
            imageList: [
                { id: 0, idView: require("@/assets/l1.jpg") },
                { id: 1, idView: require("@/assets/l2.jpg") },
                { id: 2, idView: require("@/assets/l3.jpg") },
                { id: 3, idView: require("@/assets/l4.jpg") },
                { id: 4, idView: require("@/assets/l5.jpg") },
                { id: 5, idView: require("@/assets/l6.jpg") },
            ]
        };
    },

    created() {
        this.getid();
        this.getname();
    },

    methods: {
        getid() {
            this.user_id = global_msg.nowuserid; //这里用全局默认id值，后续可能需要更改？
            console.log(this.user_id);
        },

        getname() {
            let param = {
                ID: this.user_id
            };

            getInfo(param).then((res) => {
                if (res.data) {
                    console.log(param);
                    console.log(res);
                    this.user_name = res.data[0].user_name;
                    console.log(this.user_name);
                }
                else {
                    alert("info error");
                }
            })

        },

        Newroutes() {
            this.$router.push("/users/NoticeList"); //这里左侧的颜色显示有点问题，看看之后解决一下
        }
    }
}
</script>

<style>
#bigbox {
    margin-left: 15%;
}

.card-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
}

.text {
    font-size: 14px;
}

.item {
    margin-bottom: 18px;
}

.box-card {
    width: 430px;
    height: 400px;
}
</style>


<style>
.el-calendar-table .el-calendar-day {
    height: 30px;
}
</style>

<style>
._index {
    background: #c8cfd8;
    width: 80%;
    text-align: center;
    margin-left: 142px;
    width: 80.6%;

}

.el-carousel__item h3 {
    color: #475669;
    font-size: 14px;
    opacity: 0.75;
    line-height: 200px;
    margin: 0;
}

.el-carousel__item:nth-child(2n) {
    background-color: #99a9bf;
}

.el-carousel__item:nth-child(2n+1) {
    background-color: #d3dce6;
}
</style>

