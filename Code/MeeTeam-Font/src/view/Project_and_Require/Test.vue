<template>
    <div v-if="reset">
        <div style="margin-left:1%;margin-right:1%">
            <el-row>
                <el-col :span="4" v-for="(item) in tabledata" :key="item.classId" :offset="1">
                    <div style="margin-top:15px">
                        <el-card :body-style="{ padding: '0px' }" shadow="hover">
                            <img src="https://shadow.elemecdn.com/app/element/hamburger.9cf7b091-55e9-11e9-a976-7f4d0b07eef6.png"
                                class="image">
                            <div>
                                <span>{{ item.classGrade }}级{{ item.classMajor }}系{{ item.classNumber }}班</span><br>
                                <div class="bottom clearfix">
                                    <time class="time"><strong>创建时间:</strong>{{ item.classCreatetime }}</time>
                                    <el-button type="text" class="button" @click="add(item)">查看</el-button>
                                </div>
                            </div>
                        </el-card>
                    </div>
                </el-col>
            </el-row>
            <div style="margin-left:35%">
                <div class="block">
                    <el-pagination @size-change="handleSizeChange" @current-change="handleCurrentChange"
                        :current-page="current_page" :page-sizes="[4, 8, 12, 16]" :page-size="pagesize"
                        layout="total, sizes, prev, pager, next" :total="total">
                    </el-pagination>
                </div>
            </div>

        </div>
    </div>
</template>


<script>
//import grade from './grade'
//import classnum1 from './classnum'
//import major from './major'

export default {
    name: 'classList',
    /*
    components: {
        'child1': major,
        'child2': grade,
        'child3': classnum1,
    },
    */
    data() {
        return {
            tabledata: null,
            current_page: 1,
            total: null,
            pagesize: 8,
            listdata: {},
            reset: false,
            //专业的值       
            major: null,
            //年级的值        
            grade: null,
            //班级数字        
            classnum: null,
        }
    }, methods: {
        refresh() {
            location.reload();
        },
        add(item) {
            console.log("add");
            console.log(item);
            this.$router.push({ name: 'classInfo', params: { classInfo: item } });
        },
        handleSizeChange: function (size) {
            this.pagesize = size;
            //console.log(this.pagesize)                
            this.judge();
        },
        handleCurrentChange: function (currentPage) {
            this.current_page = currentPage;
            this.judge();
        },
        allAjax() {
            this.axios.get('http://localhost:8080/studentManagementSystem/selectTclassAll', {
                params: {
                    limit: this.pagesize,
                    now_page: this.current_page
                }
            }).then((response) => {
                var thiz = this;
                thiz.listdata = response.data;
                this.$set(this.$data, 'tabledata', response.data);
                //console.log(this.tabledata);        
            }).catch((response) => {
                console.log(response);
            })
        },
        pageNumAjax() {
            this.axios.get('http://localhost:8080/studentManagementSystem/selectNumByAll', {
                params: {}
            }).then((response) => {
                this.total = response.data;
                //console.log("一共有"+this.total+"条");        
            }).catch((response) => {
                console.log(response);
            })
        },
        majorClassnumGradeAjax() {
            let postData = this.$qs.stringify({
                class_major: this.major,
                class_grade: this.grade,
                class_number: this.classnum
            });
            this.axios({
                method: 'post',
                url: 'http://localhost:8080/studentManagementSystem/selectTClassByMajorGradeNumber',
                data: postData
            }).then((res) => {
                if (res.data != 'error')
                    this.tabledata = res.data
                // console.log(this.states);            
            });
        },
        majorAjax() {
            let postData = this.$qs.stringify({
                class_major: this.major,
                limit: this.pagesize,
                now_page: this.current_page,
            });
            this.axios({
                method: 'post',
                url: 'http://localhost:8080/studentManagementSystem/selectTclassByMajor',
                data: postData
            }).then((res) => {
                if (res.data != 'error')
                    this.tabledata = res.data
                // console.log(this.states);            
            });
        },
        classnumAjax() {
            let postData = this.$qs.stringify({
                class_number: this.classnum,
                limit: this.pagesize,
                now_page: this.current_page,
            });
            this.axios({
                method: 'post',
                url: 'http://localhost:8080/studentManagementSystem/selectTclassByNum',
                data: postData
            }).then((res) => {
                if (res.data != 'error')
                    this.tabledata = res.data
                // console.log(this.states);            
            });
        },
        gradeAjax() {
            let postData = this.$qs.stringify({
                class_grade: this.grade,
                limit: this.pagesize,
                now_page: this.current_page,
            });
            this.axios({
                method: 'post',
                url: 'http://localhost:8080/studentManagementSystem/selectTclassByGrade',
                data: postData
            }).then((res) => {
                if (res.data != 'error')
                    this.tabledata = res.data
                // console.log(this.states);            
            });
        },
        pageMajorClassnumGradeAjax() {
            this.total = 1
        },
        pageMajorAjax() {
            let postData = this.$qs.stringify({
                class_major: this.major
            });
            this.axios({
                method: 'post',
                url: 'http://localhost:8080/studentManagementSystem/selectNumByMajor',
                data: postData
            }).then((res) => {
                if (res.data != 'error')
                    this.total = res.data;
                // console.log(this.states);           
            });
        },
        pageClassnumAjax() {
            this.axios.get('http://localhost:8080/studentManagementSystem/selectNumByNum', {
                params: {
                    class_number: this.classnum
                }
            }).then((response) => {
                this.total = response.data;
                //console.log("一共有"+this.total+"条");        
            }).catch((response) => {
                console.log(response);
            })
        },
        pageGradeAjax() {
            this.axios.get('http://localhost:8080/studentManagementSystem/selectNumByGrade', {
                params: {
                    class_grade: this.grade
                }
            }).then((response) => {
                this.total = response.data;
                //console.log("一共有"+this.total+"条");        
            }).catch((response) => {
                console.log(response);
            })
        },
        setGrade(value) {
            this.grade = value;
            //console.log('setGrade:'+this.grade);    
        }, setClassnum(value) {
            this.classnum = value.value;
            //console.log(value.value);      
            //console.log('setClassnum:'+this.classnum);    
        },
        setMajor(value) {
            this.major = value;
            //console.log(this.major);    
        },
        judgeClassData() {
            if (this.major && this.classnum && this.grade) {
                console.log('major num grade not null');
                this.majorClassnumGradeAjax();
                this.pageMajorClassnumGradeAjax();
            } else if (this.major) {
                console.log('major not null');
                this.majorAjax();
                this.pageMajorAjax();
            } else if (this.grade) {
                console.log('grade not null');
                this.gradeAjax();
                this.pageGradeAjax();
            } else if (this.classnum) {
                console.log('classnum not null');
                this.classnumAjax();
                this.pageClassnumAjax();
            } else {
                this.$message('请选择班级||专业||班级序号');
            }
        },
        judge() {
            if (this.major && this.classnum && this.grade) {
                console.log('major num grade not null');
                this.majorClassnumGradeAjax();
            } else if (this.major) {
                console.log('major not null');
                this.majorAjax();
            } else if (this.grade) {
                console.log('grade not null');
                this.gradeAjax();
            } else if (this.classnum) {
                console.log('classnum not null');
                this.classnumAjax();
            } else {
                this.allAjax();
            }
        },
        selectClassData() {
            this.judgeClassData();
        }
    },
    beforeMount() {
        this.allAjax();
        this.pageNumAjax();
    },
    mounted() {
    },

    watch: {
        tabledata: function () {
            this.$nextTick(function () {
                /*现在数据已经渲染完毕*/
                //console.log(this.tabledata);          
                this.reset = true;
            })
        }
    }
}
</script>

    <style scoped>
    .time {
        font-size: 13px;
        color: #999;
    }
    
    .bottom {
        margin-top: 13px;
        line-height: 12px;
    }
    
    .button {
        padding: 0;
        float: right;
    }
    
    .image {
        width: 100%;
        display: block;
    }
    
    .clearfix:before,
    .clearfix:after {
        display: table;
        content: "";
    }
    
    .clearfix:after {
        clear: both
    }
    </style>
    