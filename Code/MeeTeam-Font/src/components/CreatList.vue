<template>
 <div>
    <!--页头-->
    <div id="header"> 
      <h2 style="display:inline-block;margin-left:40px">发布组队需求</h2>
    </div>
   <el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="100px" class="demo-ruleForm">
  <el-form-item label="组队目的" prop="purpose">
    <el-input  v-model="ruleForm.purpose"></el-input>
  </el-form-item>
  <el-form-item label="组队类型" prop="team_type">
    <el-select v-model="ruleForm.team_type" placeholder="请选择组队类型">
      <el-option label="竞赛组队" value="竞赛"></el-option>
      <el-option label="课程项目组队" value="课程项目"></el-option>
    </el-select>
  </el-form-item>
<el-form-item label="组队人数" prop="team_limit">
   <el-select v-model="ruleForm.team_limit" placeholder="请选择组队人数">
   <el-option label="3" value="3"></el-option>
      <el-option label="4" value="4"></el-option>
      <el-option label="5" value="5"></el-option>
    </el-select>
  </el-form-item>
  <el-form-item label="需求细则" prop="details">
    <el-input type="textarea" v-model="ruleForm.details"></el-input>
  </el-form-item>
  <el-form-item>
    <el-button type="primary" @click="submitForm('ruleForm')">立即创建</el-button>
    <el-button @click="resetForm('ruleForm')">重置</el-button>
  </el-form-item>
</el-form>

  </div>
</template>

<script>
import global_msg from '../utils/global.js'
import {creatlist} from '@/api/creatlist.js'
  export default {
    name: 'CreatList',
    data() {
      return {
        ruleForm: {
          require_id:'',
          purpose:'',
          team_type:'',
          team_limit:'',
          details:'',       
          require_status:'',
          originator_id:'',
          project_id:''
        },
        rules: {
          purpose: [
            { required: true, message: '请输入组队目的', trigger: 'blur' },
            { min: 3, max: 80, message: '长度在 3-80 个字符以内', trigger: 'blur' }
          ],
          team_type: [
            { required: true, message: '请选择组队类型', trigger: 'change' }
          ],
          details: [
            { required: true, message: '请填写需求细则', trigger: 'blur' },
             { min: 3, max: 100, message: '长度在 3-100 个字符以内', trigger: 'blur' }
          ],
          team_limit:[
           { required: true, message: '请选择组队人数', trigger: 'change' }
          ]
        }
      };
    },
    methods: {
      submitForm(formName) {
        this.$refs[formName].validate((valid) => {
          if (valid) {
            console.log('submit!');
          } else {
            console.log('error submit!!');
            return false;
          }
        });
      global_msg.requirenum+=3;//全局需求个数+1
      global_msg.projectnum+=1;//全局项目个数+1
      this.ruleForm.project_id=global_msg.projectnum;//得到全局项目个数
      this.ruleForm.require_id=global_msg.requirenum;//得到全局需求个数
      this.ruleForm.originator_id=global_msg.nowuserid;//得到全局userid
      this.ruleForm.require_status='0/'+this.ruleForm.team_limit;//改成了0/人数
      alert(this.ruleForm.require_id)
            //  alert(this.ruleForm.purpose)
            //  alert(this.ruleForm.team_type)
            //  alert(this.ruleForm.team_limit)
            //  alert(this.ruleForm.details)
      alert(this.ruleForm.require_status)
      alert(this.ruleForm.originator_id)
      alert(this.ruleForm.project_id)
      let vm=this;
      //请求地址,this和vm指的是全局
      let param={
        require_id:this.ruleForm.require_id,
        purpose:this.ruleForm.purpose,
        team_type:this.ruleForm.team_type,
        team_limit:this.ruleForm.team_limit,
        details:this.ruleForm.details,         
        require_status:this.ruleForm.require_status,
        originator_id:this.ruleForm.originator_id,
        project_id:this.ruleForm.project_id
      }
      creatlist(param).then(function(res){
        if(res.data===false){
          vm.$message.error("提交失败");
          vm.resetForm(formName);
        }else{
          vm.$message.success("提交成功");
          vm.$router.push({path: "/users/InforList"}); //接下来进入到哪个路由
        }
      })
      },
      resetForm(formName) {
        this.$refs[formName].resetFields();
      }
    }
  }
</script>

<style>
#header {
  text-align: left;
  height: 50px;
  background-color: white;
}
</style>