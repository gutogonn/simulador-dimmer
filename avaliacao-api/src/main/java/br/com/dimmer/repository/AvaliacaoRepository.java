package br.com.dimmer.repository;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Repository;

import br.com.dimmer.domain.Avaliacao;
import br.com.dimmer.repository.rowmapper.AvaliacaoRowMapper;

@Repository
public class AvaliacaoRepository {
	
	@Autowired
	JdbcTemplate jdbcTemplate;
	
	public List<Avaliacao> listar() {		
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT codigo, nome, erros, tempo FROM avaliacoes");
		return jdbcTemplate.query(sql.toString(), new AvaliacaoRowMapper());
	}
	
    public Avaliacao salvar(Avaliacao avaliacao)  {    	
		StringBuilder sql = new StringBuilder();
		sql.append("INSERT INTO avaliacoes ");
		sql.append("(nome, erros, tempo) ");
		sql.append("VALUES ");
		sql.append("(?, ?, ?)");
				
		jdbcTemplate.update(sql.toString(), new Object[] {
				avaliacao.getNome(),
				avaliacao.getErros(),
				avaliacao.getTempo()
		});
		
        return avaliacao;
    }

	public Avaliacao buscar(long codigo) {
    	StringBuilder sql = new StringBuilder();
		sql.append("SELECT codigo, nome, erros, tempo FROM avaliacoes WHERE codigo = ?");
		return jdbcTemplate.queryForObject(sql.toString(), new Object[] {codigo}, new AvaliacaoRowMapper());
    }
}
