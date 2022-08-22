<template>
<div id="AuditProject"> 
    <div id="body">
            <el-main>
                <div id="breadcrumb">
                    <el-breadcrumb separator-class="el-icon-arrow-right">
                        <el-breadcrumb-item :to="{ path: '/Admin/AdminPage' }">首页</el-breadcrumb-item>
                        <el-breadcrumb-item>审核管理</el-breadcrumb-item>
                        <el-breadcrumb-item>项目审核</el-breadcrumb-item>
                    </el-breadcrumb>
                </div>
                <el-card>
                    <el-row>
                        <el-col :span="10">
                            <el-input placeholder="请输入搜索内容" v-model="input3" class="input-with-select">
                              <el-select v-model="select" slot="prepend" placeholder="请选择搜索项">
                                 <el-option label="项目名称" value="1"></el-option>
                                 <el-option label="发布人" value="2"></el-option>
                              </el-select>
                              <el-button slot="append" icon="el-icon-search"></el-button>
                            </el-input>
                        </el-col>
                        <el-col :span="5">
                        </el-col>
                    </el-row>
                </el-card>
            </el-main>
        </div>
</div>
</template>

<script>
export default{
    data(){
        return{
            input1: '',
            input2: '',
            select: ''
        }
    }
}
</script>

<style>
    .el-main {
  margin-left: 8%;
}

#body {
  position: relative;
  min-height: 100vh;
  height: 100%;
}

#breadcrumb{
  height: 30px;
  margin-bottom: 10px;
}
.el-card{
    box-shadow:0 1px 1px rgba(0,0,0,0,15);
}
.el-select{
    width:134px;
}
</style>